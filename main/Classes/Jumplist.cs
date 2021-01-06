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

        private JumpListCustomCategory userShortcutCategory;

        public void buildJumplist(Category category)
        {
            userShortcutCategory = new JumpListCustomCategory("Recently Opened Applications");

            foreach (ProgramShortcut programShortcut in category.recentlyOpened)
            {
                JumpListLink recentlyOpenedShortcut = new JumpListLink(MainPath.exeString, programShortcut.name);
                recentlyOpenedShortcut.Arguments = category.Name + " " + programShortcut.name;
                userShortcutCategory.AddJumpListItems(recentlyOpenedShortcut);
            }

            list.AddCustomCategories(userShortcutCategory);

            JumpListCustomCategory userTaskbarCategory = new JumpListCustomCategory("Taskbar Groups");
            JumpListLink openAllShortcuts = new JumpListLink(MainPath.exeString, "Open all shortcuts");
            openAllShortcuts.Arguments = category.Name + " tskBaropen_allGroup";

            JumpListLink openEdit = new JumpListLink(MainPath.exeString, "Edit Group");
            openEdit.Arguments = "editingGroupMode " + category.Name;

            userTaskbarCategory.AddJumpListItems(openEdit);
            userTaskbarCategory.AddJumpListItems(openAllShortcuts);
            list.AddCustomCategories(userTaskbarCategory);

            list.Refresh();
        }

        public void addItemToShortcutCut(Category category, ProgramShortcut programShortcut)
        {
            JumpListLink recentlyOpenedShortcut = new JumpListLink(MainPath.exeString, programShortcut.name);
            recentlyOpenedShortcut.Arguments = category.Name + " " + programShortcut.name;
            userShortcutCategory.AddJumpListItems(recentlyOpenedShortcut);

            list.Refresh();
        }
    }
}
