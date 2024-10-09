using MediaBazaar.Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar.Logic_Layer
{
    public class ReShelfRequest
    {
        private string? message;
        private Product product;
        private string? reason;
        private string? sender;
        private DateTime? dateSent;
        private string? dateSentString;

        private ProductManagement pm;

        public List<ReShelfRequest> Requests;

        public string? Message
        {
            get { return message; }
            set { message = value; }
        }

        public Product Product
        {
            get { return product; }
            set { product = value; }
        }

        public string? Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        public string Sender
        {
            get { return sender; }
            set { sender = value; }
        }

        public DateTime? DateSent
        {
            get { return dateSent; }
            set { dateSent = value; }
        }

        public string? DateSentString
        {
            get { return dateSentString; }
            set { dateSentString = value; }
        }

        //multiple constructors, because there won't always be a message or reason with the request 
        public ReShelfRequest(Product requestedproduct, string message)
        {
            this.product = requestedproduct;
            this.message = message;
            this.reason = null;
        }

        public ReShelfRequest(Product requestedproduct, string sender, DateTime timesent)
        {
            this.product = requestedproduct;
            this.message = null;
            this.reason = null;
            this.sender = sender;
            this.dateSent = timesent;
        }
        public ReShelfRequest(Product requestedproduct, string sender, string timesent)
        {
            this.product = requestedproduct;
            this.message = null;
            this.reason = null;
            this.sender = sender;
            this.dateSentString = timesent;
        }

        public ReShelfRequest(Product requestedproduct)
        {
            this.product = requestedproduct;
            this.message = null;
            this.reason = null;
        }

        public ReShelfRequest(Product requestedproduct, string message, string reason,string sender, DateTime dateRequested)
        {
            this.product = requestedproduct;
            this.message = message;
            this.reason = reason;
            this.sender = sender;
            this.dateSent = dateRequested;
        }

        public ReShelfRequest(Product requestedproduct, string message, string sender, DateTime dateRequested)
        {
            this.product = requestedproduct;
            this.message = message;
            this.reason = null;
            this.sender = sender;
            this.dateSent = dateRequested;
        }

        public ReShelfRequest(Product requestedproduct, string message, string sender, string dateRequested)
        {
            this.product = requestedproduct;
            this.message = message;
            this.reason = null;
            this.sender = sender;
            this.dateSentString = dateRequested;
        }

        public List<ReShelfRequest> GetRequestList()
        {
            return Requests;
        }

        public void AddRequest(ReShelfRequest request)
        {
            Requests.Add(request);
        }

        public ReShelfRequest GetRequestByProduct(Product product)
        {
            foreach (ReShelfRequest request in Requests)
            {
                if (request.product.Name == product.Name)
                {
                    return request;
                }
            }
            return null;
        }

        public void RemoveRequest(ReShelfRequest request)
        {
            Requests.Remove(request);
        }

        public void AcceptRequest(ReShelfRequest request)
        {
            request.product.AmountInstock += 100;
            pm.EditProduct(request.product, request.product.Name, 100);
            RemoveRequest(request);
        }

        public void RejectRequest(ReShelfRequest request)
        {
            RemoveRequest(request);
        }
    }
}
