using Fortigate_Gui.Data;
using Fortigate_Gui.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Script
{
    public class DownloadScript
    {
        private List<Interface> _interfaces;
        private List<FirewallAddress> _firewallAddresses;
        private List<Zone> _zones;
        private List<Ip4Policy> _ip4Policies;
        private List<StaticRoute> _staticRoutes;
        private readonly ApplicationDbContext _context;
        public DownloadScript(List<Interface> interfaces, List<FirewallAddress> firewallAddresses,
            List<Zone> zones, List<Ip4Policy> ip4Policies, List<StaticRoute> staticRoutes, ApplicationDbContext context)
        {
            _zones = zones;
            _interfaces = interfaces;
            _firewallAddresses = firewallAddresses;
            _ip4Policies = ip4Policies;
            _staticRoutes = staticRoutes;
            _context = context;

        }

        public async Task<string> StreamScriptAsync()
        {
            using (StreamWriter stream = new StreamWriter(@"wwwroot/files/conffile.txt"))
            {
                ReadFilter readFilter = new ReadFilter();
                List<string> Lines = readFilter.ReadLines();
                foreach (string Line in Lines)
                {
                    stream.WriteLine(Line);
                }
                // Send the command
                if (_interfaces == null)
                {
                    _interfaces = new List<Interface>();
                }
                stream.WriteLine("config system interface");
                foreach (var item in _interfaces)
                {
                    Interface @interface = await _context.Interfaces
                        .Include(x => x.EnumMode)
                        .Include(x => x.EnumType)
                        .Include(x => x.AccessInterfaces)
                        .ThenInclude(ai => ai.EnumAcces)
                        .Include(x => x.EnumPhysical)
                        .SingleOrDefaultAsync(z => z.InterfaceID == item.InterfaceID);

                    stream.WriteLine("edit " + @interface.Name);
                    stream.WriteLine("set alias " + @interface.Alias);
                    stream.WriteLine("set vdom root");
                    stream.WriteLine("set mode static");
                    stream.WriteLine("set ip " + @interface.Ip + " " + @interface.Subnet);
                    string AllowAccess = "";
                    foreach (var accessInterface in @interface.AccessInterfaces)
                    {
                        AllowAccess += accessInterface.EnumAcces.Name + " ";
                    }
                    stream.WriteLine("set allowaccess " + AllowAccess);
                    if (@interface.EnumType.Name == "VLAN")
                    {
                        stream.WriteLine("set type vlan");
                        stream.WriteLine("set interface " + @interface.VlanInterface);
                        stream.WriteLine("set vlanid " + @interface.VlanId.ToString());
                    }
                    stream.WriteLine("next");
                }
                stream.WriteLine("end");
                stream.WriteLine("config system zone");
                
                if (_zones == null)
                {
                    _zones = new List<Zone>();
                }
                foreach (var item in _zones)
                {
                    Zone zone = await _context.Zones.Include(x => x.ZoneInterfaces).ThenInclude(zi => zi.Interface)
                        .SingleOrDefaultAsync(y => y.ZoneID == item.ZoneID);
                    stream.WriteLine("edit " + zone.Name);
                    string lineZone = "";
                    foreach (ZoneInterface zi in zone.ZoneInterfaces)
                    {
                        lineZone += zi.Interface.Name + " ";

                    }
                    stream.WriteLine("set interface " + lineZone);
                    stream.WriteLine("next");
                }
                stream.WriteLine("end");
                if (_firewallAddresses == null)
                {
                    _firewallAddresses = new List<FirewallAddress>();
                }
                foreach (var item in _firewallAddresses)
                {
                    stream.WriteLine("config firewall address");
                    stream.WriteLine("edit " + item.Name);
                    stream.WriteLine("set associated-interface " + item.AssociatedZone);
                    stream.WriteLine("set subnet " + item.Subnet);
                    stream.WriteLine("next");
                }
                stream.WriteLine("end");

                int i = 0;
                if (_ip4Policies == null)
                {
                    _ip4Policies = new List<Ip4Policy>();
                }
                foreach (var item in _ip4Policies)
                {
                    i++;
                    Ip4Policy ip4Policy = await _context.Ip4Policies
                        .Include(x => x.SourceInterface)
                        .Include(y => y.DestinationInterface)
                        .Include(z => z.Action)
                        .Include(t => t.Nat)
                        .SingleOrDefaultAsync(z => z.Ip4PolicyID == item.Ip4PolicyID);
                    stream.WriteLine("config firewall policy");
                    stream.WriteLine("edit 2");
                    stream.WriteLine("set srcintf " + ip4Policy.SourceInterface.Name);
                    stream.WriteLine("set dstintf " + ip4Policy.DestinationInterface.Name);
                    stream.WriteLine("set srcaddr " + ip4Policy.SourceAddress);
                    stream.WriteLine("set dstaddr " + ip4Policy.DestinationAddress);
                    stream.WriteLine("set schedule always");
                    stream.WriteLine("set fsso disable");
                    stream.WriteLine("set action " + ip4Policy.Action.Name);
                    stream.WriteLine("set service ALL");
                    stream.WriteLine("set logtraffic all");
                    stream.WriteLine("set nat " + ip4Policy.Nat.Name);
                    stream.WriteLine("set utm-status enable");
                    if (ip4Policy.AvFilter == true)
                    {
                        stream.WriteLine("set av-profile AV_FILTER");
                    }
                    stream.WriteLine("set webfilter-profile WEB_FILTER");
                    stream.WriteLine("set dnsfilter-profile DNS_FILTER");
                    stream.WriteLine("set ips-sensor IPS_FILTER");
                    stream.WriteLine("set application-list APP_FILTER");
                    stream.WriteLine("set profile-protocol-options PROXY_FILTER");
                    stream.WriteLine("set ssl-ssh-profile certificate-inspection");
                    stream.WriteLine("next");
                }
                stream.WriteLine("end");
                // Read with a suitable timeout to avoid hanging
                int j = 0;
                if (_staticRoutes == null)
                {
                    _staticRoutes = new List<StaticRoute>();
                }
                foreach (var item in _staticRoutes)
                {
                    j++;
                    StaticRoute staticRoute = await _context.StaticRoutes
                        .Include(x => x.Interface)
                        .SingleOrDefaultAsync(y => y.StaticRouteID == item.StaticRouteID);
                    stream.WriteLine("config router static");
                    stream.WriteLine("edit " + j.ToString());
                    stream.WriteLine("set dst " + item.DestinationSubnet);
                    stream.WriteLine("set gateway " + item.Gateway);
                    stream.WriteLine("set device " + staticRoute.Interface.Name);
                    stream.WriteLine("next");
                }
                stream.WriteLine("end");

                return "ok";
            }


        }

    }
}
