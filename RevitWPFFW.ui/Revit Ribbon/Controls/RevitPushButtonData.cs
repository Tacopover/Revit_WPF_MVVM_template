﻿using System;
using Autodesk.Revit.UI;
using PB.RevitWPFFW.res;
using PB.RevitWPFFW.core;

namespace PB.RevitWPFFW.ui
{
    public class RevitPushButtonData
    {
        #region private Fields
        private readonly string _nameGuid = Guid.NewGuid().ToString();
        private readonly string _name;

        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the button name
        /// Returns an autogenerated Guid if no name is provided
        /// </summary>
        public string Name
        {
            get
            {
                if (null == _name)
                    return _nameGuid;
                else
                    return _name;
            }
        }

        /// <summary>
        /// Gets or sets button label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets Panel name
        /// </summary>
        public RibbonPanel Panel { get; set; }

        /// <summary>
        /// Gets or sets the command namespace path
        /// </summary>
        public string CommandNamespacePath { get; set; }

        /// <summary>
        /// Gets or sets the tooltip
        /// </summary>
        public string Tooltip { get; set; }

        /// <summary>
        /// Gets or sets the Long Desription
        /// </summary>
        public string LongDescription { get; set; }

        /// <summary>
        /// Gets or sets the icon image name
        /// </summary>
        public string IconImageName { get; set; }

        /// <summary>
        /// Gets or sets the small icon image name
        /// </summary>
        public string SmallIconImageName { get; set; }

        /// <summary>
        /// Gets or sets the tooltip image name
        /// </summary>
        public string TooltipImageName { get; set; }

        /// <summary>
        /// Gets or sets the availability class name
        /// </summary>
        public string AvailabilityClassName { get; set; }

        /// <summary>
        /// Gets or sets the ContextualHelp object information
        /// </summary>
        public RevitContextualHelpData ContextualHelpData { get; set; }

        #endregion

        #region Default Constructor
        /// <summary>
        /// Constructor - Uses Guid for Name
        /// </summary>
        public RevitPushButtonData() { }

        /// <summary>
        /// Constructor - user provided name
        /// </summary>
        /// <param name="name">Pushbutton Name for Future Access</param>
        public RevitPushButtonData(string name)
        {
            _name = name;
        }

        #endregion

        #region Public Methods
        public PushButtonData Create()
        {
            //The button name based on unique identifier
            string btnDataName;

            if (null == Name)
                return null;
            else
                btnDataName = Name;

            //Create The button
            var btnData = new PushButtonData(btnDataName, Label, ApplicationAssembly.GetAssemblyLocation(), CommandNamespacePath);

            //Add Tooltips, Image Data, and Availability Class Info
            if (null != Tooltip)
                btnData.ToolTip = Tooltip;

            if (null != LongDescription)
                btnData.LongDescription = LongDescription;

            if (null != ResourceImage.GetIcon(IconImageName))
                btnData.LargeImage = ResourceImage.GetIcon(IconImageName);

            if (null != ResourceImage.GetIcon(TooltipImageName))
                btnData.ToolTipImage = ResourceImage.GetIcon(TooltipImageName);

            if (null != SmallIconImageName)
                btnData.Image = ResourceImage.GetIcon(SmallIconImageName);

            if (null != AvailabilityClassName)
                btnData.AvailabilityClassName = AvailabilityClassName;

            if (null != ContextualHelpData)
                btnData.SetContextualHelp(ContextualHelpData.ContextualHelp);

            //return PushButtonData object
            return btnData;

        }
        #endregion
    }
}