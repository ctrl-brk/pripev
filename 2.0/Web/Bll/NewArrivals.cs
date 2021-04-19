using System.Data;
using Pripev.DAL;

namespace Pripev.BLL
{
    public class NewArrivals
    {
        private readonly DataRow _dr;

        public NewArrivals(int days)
        {
            _dr = DB.ExecuteDataRow("exec GetNews @Days=" + days);
        }

        public int Artists
        {
            get { return (System.Convert.ToInt32(_dr["Artists"])); }
        }

        public int Albums
        {
            get { return (System.Convert.ToInt32(_dr["Albums"])); }
        }

        public int Texts
        {
            get { return (System.Convert.ToInt32(_dr["Texts"])); }
        }

        public int Sounds
        {
            get { return (System.Convert.ToInt32(_dr["Sounds"])); }
        }
    }
}
