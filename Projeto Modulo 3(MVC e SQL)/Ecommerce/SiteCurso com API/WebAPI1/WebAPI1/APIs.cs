using System.Data.SqlClient;

namespace WebAPI1
{
    public static class APIs
    {
        public class prmItem
        {
            public int isbn { get; set; }
            public string titulo { get; set; }
            public string autor { get; set; }
            public string nomeimagem { get; set; }
        }
        public static void RegisterAPIs(this WebApplication app)
        {
            app.MapGet("/catalog", GetCatalog);
            app.MapGet("/getitem", GetItem);
            app.MapGet("/maisvendidos", MaisVendidos);
            app.MapPost("/saveitem", SaveItem);
            app.MapPost("/savevendas", SaveVendas);
        }
        public static IResult GetCatalog(string search = "")
        {
            string connString = Utils.GetAppKey("ConnectionStrings", "ConnectionAPI").ToString();
            SqlConnection cn = BD.OpenBD(connString);

            string SQL= "";

            if (search.Trim() != "")
            {
                 SQL = "SELECT * FROM curso WHERE titulo LIKE'%" + search + "%'";
            }

            SQL = "SELECT * FROM curso";
            return Results.Ok(BD.ToListDictionary(cn, SQL));
        }

       

        public static IResult GetItem(int id)
        {
            string connString = Utils.GetAppKey("ConnectionStrings", "ConnectionAPI").ToString();
            SqlConnection cn = BD.OpenBD(connString);

            string SQL = "SELECT * FROM curso WHERE isbn LIKE " + id;
            return Results.Ok(BD.ToListDictionary(cn, SQL));
        }

        public static IResult SaveItem(prmItem item)
        {

            

            string connString = Utils.GetAppKey("ConnectionStrings", "ConnectionAPI").ToString();
            SqlConnection cn = BD.OpenBD(connString);




            string SQL = "INSERT INTO curso (isbn, titulo, autor, nomeimagem) VALUES (" + item.isbn + ",'" + item.titulo + "','" + item.autor + "','" + item.nomeimagem + "')";
            return Results.Ok(BD.CmdExecute(cn, SQL));




        }

        public static IResult SaveVendas(prmItem item)
        {
            string connString = Utils.GetAppKey("ConnectionStrings", "ConnectionAPI").ToString();
            SqlConnection cn = BD.OpenBD(connString);


             string SQL = "update curso set numerovendas = numerovendas + 1 where isbn =" + item.isbn;
             return Results.Ok(BD.CmdExecute(cn, SQL));


        }

        public static IResult MaisVendidos()
        {
            string connString = Utils.GetAppKey("ConnectionStrings", "ConnectionAPI").ToString();
            SqlConnection cn = BD.OpenBD(connString);

            
            string SQL = "SELECT isbn, titulo, autor, preco, promocao, rating, nomeimagem, numerovendas FROM curso order by numerovendas desc";


            return Results.Ok(BD.ToListDictionary(cn, SQL));
        }

    }
}
