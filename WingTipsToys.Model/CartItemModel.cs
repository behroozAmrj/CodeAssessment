using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WingTipsToys.Model
{
      [Table("CartItems")]
      public class CartItemModel : BaseEntity
      {
         public string  ItemId           {get;set;} 
         public string CartId           {get;set;}
         public int  Quantity         {get;set;}
         public DateTime DateCreated      {get;set;}
         public int  ProductId        {get;set;}
      }
}
