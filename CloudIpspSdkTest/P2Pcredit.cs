﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudIpspSDK;
using CloudIpspSDK.P2pcredit;

namespace CloudIpspSdkTest
{
    [TestClass]
    public class P2PcreditTest
    {
        public int MerchantId = 1545859;
        public string SecretKey = "test";
        public string CreditKey = "testcredit";
        public string ContentType = "form";
        public string Endpoint = "payment.albpay.io";
        public string card_number = "4444555511116666";

        [TestMethod]
        public void P2PTest()
        {
            Config.MerchantId = MerchantId;
            Config.SecretKey = SecretKey;
            Config.CreditKey = CreditKey;
            Config.ContentType = ContentType;
            Config.Endpoint(Endpoint);
            string oID = Guid.NewGuid().ToString();
            var req = new P2PcreditRequest()
            {
                order_id = oID,
                amount = 10000,
                order_desc = "Проверка! checkout tests",
                currency = "UAH",
                receiver_card_number = card_number
            };
            var resp = new P2Pcredit().Post(req);

            Assert.IsNotNull(resp);
            Assert.AreEqual(oID, resp.order_id);
            Assert.AreEqual("approved", resp.order_status);
        }
    }
}