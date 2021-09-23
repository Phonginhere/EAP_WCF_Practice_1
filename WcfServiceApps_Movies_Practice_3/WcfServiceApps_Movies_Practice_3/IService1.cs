using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceApps_Movies_Practice_3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<Movies>GetAll();

        [OperationContract]
        List<Movies> Search(string Search);

        [OperationContract]
        Movie GetById(int Id);

        [OperationContract]
        void Add(Movie m);

        [OperationContract]
        void Edit(Movie m);

        [OperationContract]
        void Delete(int Id);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Movies
    {
        [DataMember]
        public int MovieId { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public System.DateTime ReleaseDate { get; set; }
        [DataMember]
        public int RunningTime { get; set; }
        [DataMember]
        public int GenreId { get; set; }
        [DataMember]
        public decimal BoxOffice { get; set; }
    
        [DataMember]
        public virtual Genres Genres { get; set; }
    }

    [DataContract]
    public class Genres
    {
        [DataMember]
        public int GenreId { get; set; }

        [DataMember]
        public string GenreName { get; set; }

        [DataMember]
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
