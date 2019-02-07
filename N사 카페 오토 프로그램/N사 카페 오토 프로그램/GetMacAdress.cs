using System.Net;
using System.Net.Sockets;

class GetMacAdress
{

    public string GetMyIP()
    {
        IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
        string myip = string.Empty;
        foreach (IPAddress ia in host.AddressList)
        {
            if (ia.AddressFamily == AddressFamily.InterNetwork)
            {
                myip = ia.ToString(); break;

            }
        }
        return myip;
    }


    public string GetMacAddress(string ip)
    {
        string macAddress = null;
        System.Management.ObjectQuery query = new System.Management.ObjectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled='TRUE'");
        System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher(query);
        foreach (System.Management.ManagementObject obj in searcher.Get())
        {
            string[] ipAddress = (string[])obj["IPAddress"];
            if (ipAddress[0] == ip && obj["MACAddress"] != null)
            {
                macAddress = obj["MACAddress"].ToString(); break;
            }
        }
        return macAddress;
    }
}