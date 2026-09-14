using System.ServiceModel;

namespace Assignment1Services
{
    [ServiceContract]
    public interface IService1
    {
        // Converts Celsius to Fahrenheit.
        [OperationContract]
        int c2f(int c);

        // Converts Fahrenheit to Celsius.
        [OperationContract]
        int f2c(int f);

        // Sorts comma-separated numbers in ascending order.
        [OperationContract]
        string sort(string s);
    }
}