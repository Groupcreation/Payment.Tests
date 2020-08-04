using NUnit.Framework;
using System.Collections.Generic;
using Payment.Models;
using Moq;
using Payment.Controllers;
using System.Linq;
using Payment.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Payment.Tests
{

    public class Tests
    {
        
        List<CardDetails> card = new List<Payment.Models.CardDetails>
                {
                new CardDetails{CreditCardNumber=32,CreditLimit=34000,ProcessingCharge=570},
                new CardDetails{CreditCardNumber=323,CreditLimit=400,ProcessingCharge=670},
                new CardDetails{CreditCardNumber=321,CreditLimit=24000,ProcessingCharge=700}
                };

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            CardDetails ob = new CardDetails();
            foreach (CardDetails k in card)
            {
                ob = k;
               

                var mock = new Mock<IPayment>();
                mock.Setup(p => p.ProcessPayment(ob)).Returns(mock.Object);
                ProcessPaymentController process = new ProcessPaymentController(mock.Object);
                var res = process.ProcessPayment(ob);
                var rescheck = res as OkObjectResult;
                Assert.AreEqual(200, rescheck.StatusCode);
            }
        }
    }
}
    

