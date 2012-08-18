using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using OpenQA.Selenium;
using UIT.iDeal.TestLibrary.Browsers.Helpers.Extensions;

namespace UIT.iDeal.TestLibrary.Browsers.PageObjects
{
    public abstract class Page
    {
        public static string BaseUrl { get; set; }
        protected internal IWebDriver Browser;

        public Page(IWebDriver browser, bool navigateToPage = false)
        {
            Browser = browser;       
     
            if (navigateToPage)
            {
                NavigateTo();
            }
        
            // TODO: change this to PageId
            if (Browser.Title != PageTitle)
            {
                string message = string.Format("The Page should be {0}, but is actually {1}.", PageTitle, browser.Title);
                throw new InvalidOperationException(message);
            }
        }

        protected void NavigateTo()
        {
            Browser.NavigateTo(PageUrl);
        }

        public abstract string PageId { get; }
        public abstract string PageTitle { get; }
        public abstract string PageUrl { get; }
    }

    public abstract class Page<TForm> : Page
        where TForm: class, new()
    {
        protected TForm Model { get; private set; }
        protected FluentView<TForm> View { get; private set; }
        protected FluentForm<TForm> Form { get; private set; }

        protected Page(IWebDriver browser, bool navigateToPage = false) : base(browser, navigateToPage)
        {
            Model = new TForm();
            View = new FluentView<TForm>(Browser);
            Form = new FluentForm<TForm>(Browser,Model);
        }

        public List<IWebElement> FormErrors
        {
            get { return Browser.FindElements(By.ClassName("field-validation-error")).ToList(); }
        }

        protected FluentForm<TForm> ForForm(TForm form)
        {
            return new FluentForm<TForm>(Browser, form);
        }

        protected FluentView<TModel> ForView<TModel>() where TModel : class,new()
        {
            return new FluentView<TModel>(Browser);
        }

        public FluentGridView<TModel> ForListView<TModel>() where TModel : class , new()
        {
            return new FluentGridView<TModel>(Browser);
        }


        public Boolean HasDropDownFor(Expression<Func<TForm, SelectList>> dropDownSelector)
        {
            return Form.HasDropDownFor(dropDownSelector);
        }

        public Boolean HasDefaultItemSelectedForDropDown(Expression<Func<TForm, SelectList>> dropDownSelector, string defaultTextItem = "Select")
        {
            return
                Form.HasNoSelectedValueForDropDown(dropDownSelector) &&
                Form.FirstItemForDropDownIs(dropDownSelector, defaultTextItem);
        }

        public String SelectedItemForDropDown(Expression<Func<TForm, SelectList>> dropDownSelector)
        {
            return
                //Form.HasNoSelectedValueForDropDown(dropDownSelector) &&
                Form.SelectedItemForDropDown(dropDownSelector);
        }

       






    }
}