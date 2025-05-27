// ----------------------------------------------------------------------
// File: 			VTextAutomaticInstaller
// Organisation: 	Virtence GmbH
// Department:   	Simulation Development
// Copyright:    	© 2019 Virtence GmbH. All rights reserved
// Author:       	Silvio Lange (silvio.lange@virtence.com)
// ----------------------------------------------------------------------

using System.Linq;
using System.Text;
using System.Threading;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Virtence.VTextEditor
{
	/// <summary>
	/// 
	/// </summary>
	public class VTextAutomaticInstaller : AssetPostprocessor
	{
		#region EVENTS
		#endregion // EVENTS

		#region CONSTANTS
		#endregion // CONSTANTS

		#region FIELDS
		#endregion // FIELDS

		#region PROPERTIES
		#endregion // PROPERTIES

		#region CONSTRUCTORS
		#endregion // CONSTRUCTORS

		#region METHODS

		/// <summary>
        /// 
        /// </summary>
        /// <param name="importedAssets"></param>
        /// <param name="deletedAssets"></param>
        /// <param name="movedAssets"></param>
        /// <param name="movedFromAssetPaths"></param>
	    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
		{
            return;
        }


        /// <summary>
        /// 
        /// </summary>
        [InitializeOnLoadMethod]
        private static void InitializeOnLoad()
        {
            return;
        }

        #endregion // METHODS

        #region EVENT HANDLERS
        #endregion // EVENT HANDLERS
    }
}
