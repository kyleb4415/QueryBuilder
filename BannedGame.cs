using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class BannedGame : IClassModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Series { get; set; }
    public string Country { get; set; }
    public string Details { get; set; }

    public bool Equals(BannedGame obj)
    {
        if (this.Id == obj.Id && this.Title == obj.Title && this.Series == obj.Series && this.Country == obj.Country && this.Details == obj.Details)
            return true;
        else
            return false;
    }
    public override string ToString()
    {
        return 
            $"Id: {Id}\n" +
            $"Title: {Title}\n" +
            $"Series: {Series}\n" +
            $"Country: {Country}\n" +
            $"Details: {Details} \n";
    }
}

