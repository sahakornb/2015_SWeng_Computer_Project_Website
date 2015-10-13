using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{
	[OperationContract]
	void DoWork();

    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "login?key={key}&Username={username}&Password={password}")]
    string getLogin(string key, string username, string password);
}
