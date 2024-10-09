using System;
using System.Collections.Generic;
using System.Text;

namespace MediaBazaar
{
    public class Complaint
    {

        private int id;
        private int employeeId;
        private string complainer;
        private string complain;
        private string topic;
        private string receiver;
        private string joker;
        private int anonymous;
        private int toALL;
        private int solved;
        private int phone;

        public int Id { get { return id; } }
        public string Complainer { get { return complainer; } set { complainer = value; } }
        public string Complain { get { return complain; } set { complain = value; } }
        public string Receiver { get { return receiver; } set { receiver = value; } }
        public string Topic { get { return topic; } set { topic = value; } }
        public int Anonymous { get { return anonymous; } set { anonymous = value; } }
        public int ToALL { get { return toALL; } set { toALL = value; } }
        public int Solved { get { return solved; } set { solved = value; } }

        public string Joker { get => joker; set => joker = value; }
        public int Phone { get => phone; set => phone = value; }
        public int EmployeeId { get => employeeId; set => employeeId = value; }

        public Complaint(int Id, string Complainer, string Receiver,string Topic, string Complain,int Anonymous,int ToALL,int Solved)
        {
            this.id = Id;
            this.complainer = Complainer;
            this.receiver = Receiver;
            this.topic = Topic;
            this.complain = Complain;
            this.anonymous = Anonymous;
            this.ToALL = ToALL;            
        }
        public Complaint(string Complainer, string Receiver, string Topic, string Complain, int Anonymous, int ToALL, int Solved)
        {

            this.complainer = Complainer;
            this.receiver = Receiver;
            this.topic = Topic;
            this.complain = Complain;
            this.anonymous = Anonymous;
            this.ToALL = ToALL;
            this.Solved = Solved;

        }

        public Complaint(int id, int empId, string complainer, string complain, string topic, string receiver, int phone, string joker, int toALL)
        {
            this.id = id;
            this.complainer = complainer;
            this.complain = complain;
            this.topic = topic;
            this.receiver = receiver;
            this.Joker = joker;
            this.phone = phone;
            this.toALL = toALL;
            this.employeeId = empId;
        }
    }
    
}
