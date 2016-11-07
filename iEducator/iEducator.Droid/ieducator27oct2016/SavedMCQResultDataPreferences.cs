using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace iEducator.Droid
{
   public class SavedMCQResultDataPreferences
    {
      public SavedMCQResultDataPreferences()
        {
            //defoult constructor


        }
        
        private static ISharedPreferences prefss = Application.Context.GetSharedPreferences("PREF_NAME_RESULT", FileCreationMode.Private);
        private static ISharedPreferencesEditor editors = prefss.Edit();
        public void SaveMCQResult(int totalAttempt,int totalRight)
        {
            editors.PutInt("attempt", totalAttempt);
            editors.PutInt("right", totalRight);
            editors.Commit();
         }
        //array for returning 2 value
        public int[] ReadMCQResult()
        {
            int[] array = new int[3];
           int a =  prefss.GetInt("attempt", 0);
           int b = prefss.GetInt("right", 0);

            int dummyValue = 100;

            array[0] = a;
            array[1] = b;
            array[2] = dummyValue;

            return array; 

        }


    }
}