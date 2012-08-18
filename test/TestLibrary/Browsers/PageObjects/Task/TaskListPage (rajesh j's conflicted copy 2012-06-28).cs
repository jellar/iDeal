using System.Collections.Generic;
using OpenQA.Selenium;
using UIT.iDeal.Common.Web;
using UIT.iDeal.ViewModel.Tasks;

namespace UIT.iDeal.TestLibrary.Browsers.PageObjects.Task
{
    public class TaskListPage : Page<TaskItemViewModel>
    {
        public TaskListPage(IWebDriver browser, bool navigateToPage = true) : base(browser, navigateToPage)
        { }

        public override string PageId
        {
            get { return LocalSiteMap.Navigation.PageIds.Tasks.Index; }
        }

        public override string PageTitle
        {
            get { return LocalSiteMap.PageText.PageTitles.Tasks.Index; }
        }

        public override string PageUrl
        {
            get { return LocalSiteMap.Navigation.Urls.Tasks.Index; }
        }
    }
}
