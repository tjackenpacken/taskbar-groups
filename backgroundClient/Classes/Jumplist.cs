using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAPICodePack.Taskbar;
using System.IO;
using System.Reflection;
using Microsoft.WindowsAPICodePack.Shell;
using IWshRuntimeLibrary;

namespace backgroundClient.Classes
{
    public class Jumplist
    {
        private JumpList list;
        public Jumplist(IntPtr windowHandle)
        {
            list = JumpList.CreateJumpListForIndividualWindow(TaskbarManager.Instance.ApplicationId, windowHandle);
            list.KnownCategoryToDisplay = JumpListKnownCategoryType.Recent;
        }

        public void buildJumplist(bool allowOpenAll, string Name)
        {

            string categoryPath = Path.Combine(Paths.ConfigPath, Name);

            JumpListCustomCategory userTaskbarCategory = new JumpListCustomCategory("Taskbar Groups");

            JumpListLink openEdit = new JumpListLink(Paths.exeString, "Edit Group");
            openEdit.Arguments = "editingGroupMode " + Name;
            openEdit.IconReference = new IconReference(Path.Combine(categoryPath, "GroupIcon.ico"), 0);
            userTaskbarCategory.AddJumpListItems(openEdit);

            if (allowOpenAll)
            {
                JumpListLink openAllShortcuts = new JumpListLink(Paths.exeString, "Open all shortcuts");
                openAllShortcuts.Arguments = Name + " tskBaropen_allGroup";
                openAllShortcuts.IconReference = new IconReference(Path.Combine(categoryPath, "GroupIcon.ico"), 0);
                userTaskbarCategory.AddJumpListItems(openAllShortcuts);
            }

            try
            {
                list.AddCustomCategories(userTaskbarCategory);

                list.Refresh();
            }
            catch { }
        }
    }
}
