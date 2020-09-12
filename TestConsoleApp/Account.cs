using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using GoWorldUnity3D;


namespace TestConsoleApp
{
    class Account : ClientEntity
    {

        const string USERNAME = "unity3dlib2";
        const string PASSWORD = "unity3dlib2";

        protected override void OnCreated()
        {
            GoWorldLogger.Info(this.ToString(), "OnCreated ...");
        }

        protected override void OnBecomeClientOwner()
        {
            GoWorldLogger.Info(this.ToString(), "OnBecomeClientOwner ...");

            // Account created, logging 
            this.CallServer("Register", USERNAME, PASSWORD);
        }

        protected override void OnDestroy()
        {
            GoWorldLogger.Info(this.ToString(), "OnDestroy ...");
        }

        protected override void Tick()
        {
            
        }

        public static new GameObject CreateGameObject(MapAttr attrs)
        {
            GameObject ob = new GameObject();
            //ob.AddComponent(typeof(Account));

            return ob;
        }

        public void ShowError(string err)
        {
            GoWorldLogger.Error("ERROR", err);

            if (err.Contains("aready exists"))
            {
                this.onRegisterSuccessfully();
            }
        }
        public void ShowInfo(string info)
        {
            GoWorldLogger.Info("INFO", info);
            if (info.Contains("Registered Successfully"))
            {
                this.onRegisterSuccessfully();
            }
        }

        private void onRegisterSuccessfully()
        {
            // register ok, start login 
            this.CallServer("Login", USERNAME, PASSWORD);
        }

        protected override void OnEnterSpace()
        {
            throw new NotImplementedException();
        }

        protected override void OnLeaveSpace()
        {
            throw new NotImplementedException();
        }

    }
}
