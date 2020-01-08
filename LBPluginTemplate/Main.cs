﻿using PluginContracts;
using PluginContracts.ObjectInterfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using PluginContracts.EventArguments;

namespace LBPluginTemplate
{
    public class Plugin : PluginContracts.ILBPlugin
    {
        //Your Plugin Information
        PluginInfo plugininfo = new PluginInfo
        {
            Name = "Examplename Plugin 2",                                   //Name of your plugin, this must not change over versions!!
            Version = new Version("3.0.0"),                                      //Version of your plugin
            Author = "TheCheatsrichter",                            //Your name ;)
            Url = new Uri("https://google.com"),                                 //The URL associated with your plugin-> website/ githubpage etc.
            Description = "I like turtles even more times 3000",
        };

        public PluginInfo PluginInfo { get { return plugininfo; } }

        //General LB Data
        private ObservableCollection<IAcc> accs;
        private IEnviroment enviroment;

        public ObservableCollection<IAcc> Accounts { set { accs = value; } get { return accs; } }   //A collection of all Accounts in LB with various functions
        public IEnviroment Enviroment { set { Enviroment = value; } get { return enviroment; } }    //Important LB folder,filepaths and client information

        //Your Plugin Handling

        public bool Init()                                          //Initialize your Plugin, will be called on each LB start
        {
            UI_Init();
            return true;
        }                         

        public bool IsUpToDate { get { return true; } }             //Return if your plugin is on the newest Version
        public bool Verify { get { return true; } }                 //Return if your plugin has set up everything successfully to work, will be used to check if the plugin should be run
        public string Update() { return @"C:\Users\Adrian\Desktop\Plugin1.dll"; }                       //Update your plugin to the newest version and return if the update was successfull, make sure that you return the correct pathg of the new dll
        public bool Uninstall() { return true; }                    //Cleanup all files/settings associated with your plugin

        //Account specific client events, will be called by Launchbuddy

        public void OnLBStart(object sender, EventArgs e)
        {
            // Do Stuff when LB Starts
        }

        public void OnLBClose(object sender, EventArgs e)
        {
            //Do Stuff when the LB Closes
        }

        public void OnClientStatusChanged(object sender, ClientStatusEventArgs e)
        {
            //Do Stuff when a client changes its Status
        }


        //#############################################
        //UI Stuff
        //#############################################


        //TabItem Instance
        private TabItem UI = new TabItem(); //Your Tab in the LB UI, set to null if you don't want to show any UI

        //Return UI for Interface, return if none is needed
        public TabItem UIContent { get { return UI; } }

        //Set Up UI
        private void UI_Init()
        {
            UI.Header = "LBTestPlugin";

            //Examplestuff
            Grid content = new Grid();
            Button bt = new Button { Content = "Useless Button" };
            content.Children.Add(bt);
            UI.Content = content;
        }
    }
}
