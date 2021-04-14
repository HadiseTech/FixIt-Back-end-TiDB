
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.Generic;
namespace fixit.Models
{
    public class ServiceData
    {
       
       
       

        public List<Service> service { get; set; }

        public int  totalPage { get; set; }

       public ServiceData(int totalPage, List<Service> service){
           this.totalPage=totalPage;
           this.service=service;
       }

       

       

       




    }

}