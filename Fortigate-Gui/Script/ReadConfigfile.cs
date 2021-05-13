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
    public class ReadConfigfile
    {
        public readonly ApplicationDbContext _context;
        public ReadConfigfile(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Interface>> ReadLinesAsync()
        {
            List<Interface> interfaces = new List<Interface>();

            using (StreamReader reader = new StreamReader("wwwroot/files/UploadConffile.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string Line = reader.ReadLine();
                    Line = Line.Replace(" ", "");
                    if (Line == "configsysteminterface")
                    {
                        bool isEnd = false;
                        while (!isEnd)
                        {
                            Interface @interface = new Interface();
                            string nextLine = reader.ReadLine();
                            nextLine = nextLine.Replace("\"", "");
                            nextLine = nextLine.Replace(" ", "");
                            isEnd = IsEnd(nextLine);
                            if (!isEnd)
                            {
                                if (nextLine.Substring(0, 4) == "edit")
                                {
                                    @interface.Name = nextLine.Substring(4, nextLine.Length - 4);
                                    bool isNext = false;
                                    while (!isNext)
                                    {
                                        string nextLine1 = reader.ReadLine();
                                        nextLine1 = nextLine1.TrimStart();
                                        isNext = IsNext(nextLine1);
                                        nextLine1 = nextLine1.Replace("\"", "");
                                        string[] lines = nextLine1.Split(" ");
                                        @interface = CheckCase(lines, @interface);
                                    }
                                    if (@interface.EnumMode == null)
                                    {
                                        @interface.EnumMode = _context.EnumModes.SingleOrDefault(x => x.Name == "static");
                                    }
                                    if (@interface.Ip != null && @interface.EnumType != null && @interface.Subnet != null)
                                    {
                                        if (@interface.EnumType.Name == "Physical")
                                        {
                                            _context.Add(@interface);
                                            await _context.SaveChangesAsync();
                                            Interface @interface1 = await _context.Interfaces.SingleOrDefaultAsync(x => x.InterfaceID == @interface.InterfaceID);
                                            interfaces.Add(@interface1);
                                        }

                                    }

                                };
                            }

                        }
                    }

                }

            }
            return interfaces;
        }

        public Interface CheckCase(string[] Line, Interface @interface)
        {
            if (Line.Length > 1)
            {
                switch (Line[1])
                {
                    case "ip":
                        @interface.Ip = Line[2];
                        @interface.Subnet = Line[3];
                        return @interface;
                    case "allowaccess":
                        @interface.AccessInterfaces = new List<AccessInterface>();
                        for (int i = 2; i < Line.Length; i++)
                        {
                            EnumAcces enumAcces = _context.EnumAcces.SingleOrDefault(x => x.Name == Line[i]);

                            AccessInterface accessInterface = new AccessInterface
                            {
                                EnumAccesID = enumAcces.EnumAccesID,
                                InterfaceID = @interface.InterfaceID
                            };
                            @interface.AccessInterfaces.Add(accessInterface);

                        }
                        return @interface;
                    case "type":
                        @interface.EnumType = _context.EnumTypes.SingleOrDefault(x => x.Name == Line[2]);
                        return @interface;
                    default:
                        return @interface;

                }
            }
            return @interface;
        }

        public bool IsNext(string line)
        {
            if (line == "next")
            {
                return true;
            }
            return false;
        }

        public bool IsEnd(string line)
        {
            if (line == "end")
            {
                return true;
            }
            return false;
        }
    }
}
