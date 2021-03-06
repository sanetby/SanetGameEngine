using Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


//iOS version of Windows class
//this is not actually smart dispatcher - it doesn't check where to run method
//for now it just execute method on UI thread
namespace Sanet.XNAEngine
{
    /// <summary>
    /// A smart dispatcher system for routing actions to the user interface
    /// thread.
    /// </summary>
    public static class SmartDispatcher
    {
        /// <summary>
        /// A single Dispatcher instance to marshall actions to the user
        /// interface thread.
        /// </summary>
        private static NSObject _instance;

        /// <summary>
        /// Backing field for a value indicating whether this is a design-time
        /// environment.
        /// </summary>
        private static bool? _designer;

        /// <summary>
        /// Requires an instance and attempts to find a Dispatcher if one has
        /// not yet been set.
        /// </summary>
        private static void RequireInstance()
        {
            
        }

        /// <summary>
        /// Initializes the SmartDispatcher system, attempting to use the
        /// RootVisual of the plugin to retrieve a Dispatcher instance.
        /// </summary>
        public static void Initialize()
        {
            _instance = new NSObject();
        }

        
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static bool CheckAccess()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Executes the specified delegate asynchronously on the user interface
        /// thread. If the current thread is the user interface thread, the
        /// dispatcher if not used and the operation happens immediately.
        /// </summary>
        /// <param name="a">A delegate to a method that takes no arguments and
        /// does not return a value, which is either pushed onto the Dispatcher
        /// event queue or immediately run, depending on the current thread.</param>
        public static void BeginInvoke(Action action)
        {
            if (NSThread.Current.IsMainThread)
            {
                action();
                return;
            }
            
            if (_instance == null)
            {
                //throw new NullReferenceException("Context");
                Initialize();
            }

            
            _instance.BeginInvokeOnMainThread(action);
            
        }
    }
}
