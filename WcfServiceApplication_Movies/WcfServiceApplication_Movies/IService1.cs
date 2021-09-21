using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceApplication_Movies
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract] //dinh nghia bieu thi interface la 1 service de ben ngoai nhin thay
    public interface IService1
    {

        [OperationContract] //dinh nghia 1 ham de ben ngoai nhin thay 
        List<Movies> GetAll();

        [OperationContract]
        List<Movies> Search(String Search);

        [OperationContract]
        Movie GetById(int id);

        [OperationContract]
        void Add(Movie m);

        [OperationContract]
        void Edit(Movie m);

        [OperationContract]
        void Delete(int id);


        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember] 
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract] //dinh nghia bieu thi 1 class de ben ngoai thay dc
    public class Genres
    {
        [DataMember] //dinh nghia bieu thi 1 thuoc tinh de ben ngoai thay dc
        public int GenreId { get; set; }
        [DataMember]
        public String GenreName { get; set; }
        
        public virtual ICollection<Movies> Movies { get; set; }
    }

    [DataContract]
    public class Movies
    {
        [DataMember]
        public int MovieId { get; set; }
        [DataMember]
        public String Title { get; set; }
        [DataMember]
        public DateTime ReleaseDate { get; set; }
        [DataMember]
        public int RunningTime { get; set; }
        [DataMember]
        public int GenreId { get; set; }
        [DataMember]
        public decimal BoxOffice { get; set; }

        public virtual Genres Genres { get; set; }
    }
}
