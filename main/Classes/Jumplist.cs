using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAPICodePack.Taskbar;
using System.IO;
using System.Reflection;
using Microsoft.WindowsAPICodePack.Shell;

namespace client.Classes
{
    public class Jumplist
    {
        private JumpList list;
        public Jumplist(IntPtr windowHandle)
        {
            list = JumpList.CreateJumpListForIndividualWindow(TaskbarManager.Instance.ApplicationId, windowHandle);
            list.KnownCategoryToDisplay = JumpListKnownCategoryType.Recent;
        }

        public void buildJumplist(Category category)
        {

            string categoryPath = Path.Combine(Paths.ConfigPath, category.Name);

            JumpListCustomCategory userTaskbarCategory = new JumpListCustomCategory("Taskbar Groups");

            JumpListLink openEdit = new JumpListLink(Paths.exeString, "Edit Group");
            openEdit.Arguments = "editingGroupMode " + category.Name;
            openEdit.IconReference = new IconReference(Path.Combine(categoryPath, "GroupIcon.ico"), 0);
            userTaskbarCategory.AddJumpListItems(openEdit);

            if (category.allowOpenAll)
            {
                JumpListLink openAllShortcuts = new JumpListLink(Paths.exeString, "Open all shortcuts");
                openAllShortcuts.Arguments = category.Name + " tskBaropen_allGroup";
                openAllShortcuts.IconReference = new IconReference(Path.Combine(categoryPath, "GroupIcon.ico"), 0);
                userTaskbarCategory.AddJumpListItems(openAllShortcuts);
            }

            list.AddCustomCategories(userTaskbarCategory);

            list.Refresh();
        }
    }
}
