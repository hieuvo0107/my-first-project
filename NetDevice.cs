using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetDevice
{
    public class DeviceUtils
    {
        public static int PNP = 0;
        public static Tuple<int, string> SendCommand(string SERVER_IP, int portNum, int COMPANY_ID, string GSM_IMEI, string command)
        {
           
            //Console.WriteLine(command);

            //Tuple<int, string> result = new Tuple<int, string>(0,"");
            TcpClient tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(IPAddress.Parse(SERVER_IP), portNum);
                NetworkStream networkStream = tcpClient.GetStream();

                if (networkStream.CanWrite && networkStream.CanRead)
                {
                    String AdminCMD = "ConfigCmd " + GSM_IMEI + ";" + command + ";" + COMPANY_ID.ToString() + ";" + GSM_IMEI + ";2G0101001\r\n";
                    String Command = AdminCMD;

                    Byte[] sendBytes = Encoding.ASCII.GetBytes(AdminCMD);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);

                    // Reads the NetworkStream into a byte buffer.
                    byte[] bytes = new byte[tcpClient.ReceiveBufferSize];
                    int BytesRead = networkStream.Read(bytes, 0, (int)tcpClient.ReceiveBufferSize);
                    // Returns the data received from the host to the console.
                    string returndata = Encoding.ASCII.GetString(bytes, 0, BytesRead);
                    String[] RES1 = returndata.Split(' ');

                    int commanresult = Int32.Parse(RES1[1].Split(';')[0]);

                    networkStream.Close();
                    tcpClient.Close();

                    return new Tuple<int, string>(commanresult, "Success");

                }
                else if (!networkStream.CanRead)
                {
                    //Console.WriteLine("You can not write data to this stream");

                    tcpClient.Close();

                    return new Tuple<int, string>(-1, "You can not write data to this stream");
                }
                else if (!networkStream.CanWrite)
                {
                    //Console.WriteLine("You can not read data from this stream");
                    tcpClient.Close();
                    return new Tuple<int, string>(-2, "You can not write data to this stream");
                    //return -2;
                }
            }
            catch (SocketException ex)
            {
                //Console.WriteLine("Sever not available!");
                return new Tuple<int, string>(-3, "Sever not available! " + ex.ToString());
                //return -3;
            }
            catch (System.IO.IOException ex)
            {
                //Console.WriteLine("Sever not available!");
                //return -4;
                return new Tuple<int, string>(-4, "Sever not available! " + ex.ToString());
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.ToString());
                //return -5;
                return new Tuple<int, string>(-5, e.ToString());
            }

            //return -6;
            return new Tuple<int, string>(-6, "");
        }

        public static Tuple<int, string> SendMapDeviceCommand(string SERVER_IP, int portNum, int COMPANY_ID, string GSM_IMEI, string bienSO,int ComID)
        {

            TcpClient tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(IPAddress.Parse(SERVER_IP), portNum);
                NetworkStream networkStream = tcpClient.GetStream();

                if (networkStream.CanWrite && networkStream.CanRead)
                {
                    String AdminCMD = "MapDevice " + GSM_IMEI + ";" + bienSO + ";" + ComID + ";" + GSM_IMEI + ";2G0101001\r\n";
                    String Command = AdminCMD;

                    Byte[] sendBytes = Encoding.ASCII.GetBytes(AdminCMD);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);

                    // Reads the NetworkStream into a byte buffer.
                    byte[] bytes = new byte[tcpClient.ReceiveBufferSize];
                    int BytesRead = networkStream.Read(bytes, 0, (int)tcpClient.ReceiveBufferSize);
                    // Returns the data received from the host to the console.
                    string returndata = Encoding.ASCII.GetString(bytes, 0, BytesRead);
                    String[] RES1 = returndata.Split(' ');

                    int commanresult = Int32.Parse(RES1[1].Split(';')[0]);

                    networkStream.Close();
                    tcpClient.Close();

                    return new Tuple<int, string>(commanresult, "Success");

                }
                else if (!networkStream.CanRead)
                {
                    //Console.WriteLine("You can not write data to this stream");

                    tcpClient.Close();

                    return new Tuple<int, string>(-1, "You can not write data to this stream");
                }
                else if (!networkStream.CanWrite)
                {
                    //Console.WriteLine("You can not read data from this stream");
                    tcpClient.Close();
                    return new Tuple<int, string>(-2, "You can not write data to this stream");
                    //return -2;
                }
            }
            catch (SocketException ex)
            {
                //Console.WriteLine("Sever not available!");
                return new Tuple<int, string>(-3, "Sever not available! " + ex.ToString());
                //return -3;
            }
            catch (System.IO.IOException ex)
            {
                //Console.WriteLine("Sever not available!");
                //return -4;
                return new Tuple<int, string>(-4, "Sever not available! " + ex.ToString());
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.ToString());
                //return -5;
                return new Tuple<int, string>(-5, e.ToString());
            }

            //return -6;
            return new Tuple<int, string>(-6, "");
        }
    }

    public class RequestDeviceUtils
    {
        public static int PNP = 0;
        public static Tuple<int, string> SendCommand(string SERVER_IP, int portNum, int COMPANY_ID, string GSM_IMEI, string command)
        {
          
            //Console.WriteLine(command);

            //Tuple<int, string> result = new Tuple<int, string>(0,"");
            TcpClient tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(IPAddress.Parse(SERVER_IP), portNum);
                NetworkStream networkStream = tcpClient.GetStream();

                if (networkStream.CanWrite && networkStream.CanRead)
                {
                    String AdminCMD = "ConfigCmd " + GSM_IMEI + ";" + command + ";" + COMPANY_ID.ToString() + ";" + GSM_IMEI + ";2G0101001\r\n";
                    String Command = AdminCMD;

                    Byte[] sendBytes = Encoding.ASCII.GetBytes(AdminCMD);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);

                    // Reads the NetworkStream into a byte buffer.
                    byte[] bytes = new byte[tcpClient.ReceiveBufferSize];
                    int BytesRead = networkStream.Read(bytes, 0, (int)tcpClient.ReceiveBufferSize);
                    // Returns the data received from the host to the console.
                    string returndata = Encoding.ASCII.GetString(bytes, 0, BytesRead);
                    String[] RES1 = returndata.Split(' ');

                    int commanresult = Int32.Parse(RES1[1].Split(';')[0]);

                    networkStream.Close();
                    tcpClient.Close();

                    return new Tuple<int, string>(commanresult, "Success");

                }
                else if (!networkStream.CanRead)
                {
                    //Console.WriteLine("You can not write data to this stream");

                    tcpClient.Close();

                    return new Tuple<int, string>(-1, "You can not write data to this stream");
                }
                else if (!networkStream.CanWrite)
                {
                    //Console.WriteLine("You can not read data from this stream");
                    tcpClient.Close();
                    return new Tuple<int, string>(-2, "You can not write data to this stream");
                    //return -2;
                }
            }
            catch (SocketException ex)
            {
                //Console.WriteLine("Sever not available!");
                return new Tuple<int, string>(-3, "Sever not available! " + ex.ToString());
                //return -3;
            }
            catch (System.IO.IOException ex)
            {
                //Console.WriteLine("Sever not available!");
                //return -4;
                return new Tuple<int, string>(-4, "Sever not available! " + ex.ToString());
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.ToString());
                //return -5;
                return new Tuple<int, string>(-5, e.ToString());
            }

            //return -6;
            return new Tuple<int, string>(-6, "");
        }
    }
}
