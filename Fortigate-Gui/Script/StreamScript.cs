using Fortigate_Gui.Data;
using Fortigate_Gui.Helper;
using Fortigate_Gui.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Script
{
    public class StreamScript
    {
        private List<Interface> _interfaces;
        private List<FirewallAddress> _firewallAddresses;
        private List<Zone> _zones;
        private List<Ip4Policy> _ip4Policies;
        private List<StaticRoute> _staticRoutes;
        public List<Group> _groups;
        public List<VpnSetting> _vpnSettings { get; set; }
        private readonly ApplicationDbContext _context;
        public StreamScript(List<Interface> interfaces, List<FirewallAddress> firewallAddresses, 
            List<Zone> zones, List<Ip4Policy> ip4Policies, List<StaticRoute> staticRoutes, List<Group> groups, List<VpnSetting> vpnSettings, ApplicationDbContext context)
        {
            _zones = zones;
            _interfaces = interfaces;
            _firewallAddresses = firewallAddresses;
            _ip4Policies = ip4Policies;
            _staticRoutes = staticRoutes;
            _groups = groups;
            _vpnSettings = vpnSettings;
            _context = context;
          
        }

        public async Task<string> StreamScriptAsync()
        {
            var connInfo = new Renci.SshNet.PasswordConnectionInfo("10.10.10.1", 221, "admin", "admin");
            var sshClient = new Renci.SshNet.SshClient(connInfo);

            sshClient.Connect();
            var stream = sshClient.CreateShellStream("", 0, 0, 0, 0, 0);
            
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
                    .Include(x => x.AccessInterfaces)
                    .ThenInclude(ai => ai.EnumAcces)
                    .Include(x => x.EnumPhysical)
                    .SingleOrDefaultAsync(z => z.InterfaceID == item.InterfaceID);
               
                stream.WriteLine("edit " + item.Name);
                stream.WriteLine("set vdom root");
                stream.WriteLine("set mode " + @interface.EnumMode.Name);
                stream.WriteLine("set ip " + item.Ip + " " + item.Subnet);
                string AllowAccess = "";
                foreach (var accessInterface in @interface.AccessInterfaces)
                {
                     AllowAccess += accessInterface.EnumAcces.Name + " ";
                }
                stream.WriteLine("set allowaccess " + AllowAccess);
                stream.WriteLine("next");
            }

            stream.WriteLine("end");
            stream.WriteLine("config system zone");
            string lineZone = "";
            if (_zones == null)
            {
                _zones = new List<Zone>();
            }
            foreach (var item in _zones)
            {
                Zone zone = await _context.Zones.Include(x => x.ZoneInterfaces).ThenInclude(zi => zi.Interface)
                    .SingleOrDefaultAsync(y => y.ZoneID == item.ZoneID);
                stream.WriteLine("edit " + zone.Name);
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
                stream.WriteLine("set nat "+ ip4Policy.Nat.Name);
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
                    .SingleOrDefaultAsync(y=> y.StaticRouteID == item.StaticRouteID);
                stream.WriteLine("config router static");
                stream.WriteLine("edit " + j.ToString());
                stream.WriteLine("set dst " + item.DestinationSubnet);
                stream.WriteLine("set gateway " + item.Gateway);
                stream.WriteLine("set device " + staticRoute.Interface.Name);
                stream.WriteLine("next");
            }
            stream.WriteLine("end");

            string members = "";
            if (_groups == null)
            {
                _groups = new List<Group>();
            }
            foreach (var item in _groups)
            {
                Group group = await _context.Groups.Include(x => x.UserGroups).ThenInclude(u => u.FortiUser)
                    .SingleOrDefaultAsync(y => y.GroupID == item.GroupID);
                foreach (UserGroup ug in group.UserGroups)
                {
                    stream.WriteLine("config user local");
                    stream.WriteLine("edit " + ug.FortiUser.Name);
                    stream.WriteLine("set type password");
                    stream.WriteLine("set passwd " + ug.FortiUser.Password);
                    stream.WriteLine("next");
                    stream.WriteLine("end");
                    members += ug.FortiUser.Name + " ";
                }
                stream.WriteLine("config user group");
                stream.WriteLine("edit " + item.Name);
                stream.WriteLine("set member " + members);
                stream.WriteLine("next");
                stream.WriteLine("end");
            }
            if (_vpnSettings != null)
            {
                stream.WriteLine("config system interface");
                stream.WriteLine("edit ssl.root");
                stream.WriteLine("set set vdom root");
                stream.WriteLine("set type tunnel");
                stream.WriteLine("set alias SSL VPN interface");
                stream.WriteLine("set role lan");
                stream.WriteLine("set snmp-index 5");
                stream.WriteLine("next");
                stream.WriteLine("end");
            }
            foreach (var item in _vpnSettings)
            {
                VpnSetting vpnSetting = await _context.VpnSettings.Include(x => x.VpnPortal)
                    .SingleOrDefaultAsync(y => y.VpnSettingID == item.VpnSettingID);
                stream.WriteLine("config vpn ssl web portal");
                stream.WriteLine("edit " + vpnSetting.VpnPortal.PortalName);
                if (vpnSetting.VpnPortal.TunnelMode == true)
                {
                    stream.WriteLine("set tunnel-mode enable");
                }
                if (vpnSetting.VpnPortal.SplitTunneling == true)
                {
                    stream.WriteLine("set split-tunneling enable");
                    stream.WriteLine("set split-tunneling-routing-address" + vpnSetting.VpnPortal.SplitTunnelingRoute);
                }
                if (vpnSetting.VpnPortal.WebMode == true)
                {
                    stream.WriteLine("set web-mode enable");
                }
                if (vpnSetting.VpnPortal.AutoConnect == true)
                {
                    stream.WriteLine("set auto-connect enable");
                }
                if (vpnSetting.VpnPortal.KeepAlive == true)
                {
                    stream.WriteLine("set keep-alive enable");
                }
                if (vpnSetting.VpnPortal.SavePassword == true)
                {
                    stream.WriteLine("set save-password enable");
                }
                stream.WriteLine("set ip-pools " + vpnSetting.VpnPortal.IpPool);
                stream.WriteLine("next");
                stream.WriteLine("end");

                stream.WriteLine("config vpn ssl settings");
                stream.WriteLine("set servercert " + vpnSetting.ServerCert);
                stream.WriteLine("set tunnel-ip-pools " + vpnSetting.TunnelIpPool);
                stream.WriteLine("set tunnel-ipv6-pools " + vpnSetting.TunnelIpv6Pool);
                stream.WriteLine("set source-interface " + vpnSetting.SourceInterface);
                stream.WriteLine("set source-address " + vpnSetting.SourceAddress);
                stream.WriteLine("set source-address6 " + vpnSetting.SourceAddressV6);
                stream.WriteLine("set default-portal " + vpnSetting.DefaultPort);
                stream.WriteLine("config authentication-rule");
                stream.WriteLine("edit 1");
                stream.WriteLine("set groups " + vpnSetting.Group.Name);
                stream.WriteLine("set portal " + vpnSetting.VpnPortal.PortalName);
                stream.WriteLine("next");
                stream.WriteLine("next");
                stream.WriteLine("end");
            }

            string response = "";
            string line;
            while ((line = stream.ReadLine(TimeSpan.FromSeconds(2))) != null)
            {
                response += line;
                // if a termination pattern is known, check it here and break to exit immediately
            }
            // ...
            stream.Close();
            // ...
            sshClient.Disconnect();

            return response;
        }
    }
}
