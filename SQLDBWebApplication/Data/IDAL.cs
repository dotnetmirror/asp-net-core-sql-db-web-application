using DotnetMirror.ASPNETCORESQLDBWebApplication.Models;

namespace DotnetMirror.ASPNETCORESQLDBWebApplication.Data
{
    public interface IDAL
    {
        List<Cert> ListCertfications();
        Cert GetCertfication(string id);
        void Save(Cert cert);
        void Update(Cert cert);
        void Delete(string code);
    }

}