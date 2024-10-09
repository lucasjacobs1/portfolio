using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar.Logic_Layer
{
    public class Product
    {
        private int id;
        private string name;
        private string description;
        private double priceInEuros;
        private int amountinstock;
        private int amountsold;
        private string barcode;
        private int? weight;
        private int? height;
        private int? length;
        private int? width;

        #region Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public double PriceInEuros
        {
            get { return priceInEuros; }
            set { priceInEuros = value; }
        }
        public int AmountInstock
        {
            get { return amountinstock; }
            set { amountinstock = value; }
        }
        public int AmountSold
        {
            get { return amountsold; }
            set { amountsold = value; }
        }
        public string Barcode
        {
            get { return barcode; }
            set { barcode = value; }
        }
        public int? WeightInKG
        {
            get { return weight; }
            set { weight = value; }
        }
        public int? HeightInCM
        {
            get { return height; }
            set { height = value; }
        }
        public int? LengthInCM
        {
            get { return length; }
            set { length = value; }
        }
        public int? WidthInCM
        {
            get { return width; }
            set { width = value; }
        }
        #endregion

        #region Constructors

        public Product(int id, string name, string description, double price, int amountinstock, int amountsold, string barcode, int weight, int height, int length, int width)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.priceInEuros = price;
            this.amountinstock = amountinstock;
            this.amountsold = amountsold;
            this.barcode = barcode;
            this.weight = weight;
            this.height = height;
            this.length = length;
            this.width = width;
        }

        public Product(string name, string description, double price, int amountinstock, int amountsold, string barcode, int weight, int height, int length, int width)
        {
            this.name = name;
            this.description = description;
            this.priceInEuros = price;
            this.amountinstock = amountinstock;
            this.amountsold = amountsold;
            this.barcode = barcode;
            this.weight = weight;
            this.height = height;
            this.length = length;
            this.width = width;
        }
        public Product(string name, string description, double price, int amountinstock, int amountsold, int weight, int height, int length, int width)
        {
            this.name = name;
            this.description = description;
            this.priceInEuros = price;
            this.amountinstock = amountinstock;
            this.amountsold = amountsold;
            this.barcode = "X";
            this.weight = weight;
            this.height = height;
            this.length = length;
            this.width = width;
        }
        public Product(string name, string description, double price, int amountinstock, int amountsold, string barcode)
        {
            this.name = name;
            this.description = description;
            this.priceInEuros = price;
            this.amountinstock = amountinstock;
            this.amountsold = amountsold;
            this.barcode = barcode;
        }
        public Product(int id, string name, string description, double price, int amountinstock, int amountsold, string barcode)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.priceInEuros = price;
            this.amountinstock = amountinstock;
            this.amountsold = amountsold;
            this.barcode = barcode;
        }

        public Product()
        {
            this.id = 0;
            this.name = "X";
            this.description = "X";
            this.priceInEuros = 0;
            this.amountinstock = 0;
            this.amountsold = 0;
            this.barcode = "X";
            this.weight = 0;
            this.height = 0;
            this.width = 0;
            this.length = 0;
        }
        #endregion
    }
}
