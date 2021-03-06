﻿using System;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using CQ.SharePoint.QN.Common;

namespace CQ.SharePoint.QN.Webparts
{
    /// <summary>
    /// QNHeaderUS
    /// </summary>
    public partial class CompanyListRightUS : UserControl
    {
        public CompanyListRight WebpartParent;
        public string NewsUrl = string.Empty;
        public string CategoryUrl = string.Empty;
        /// <summary>
        /// Page on Load
        /// </summary>
        /// <param name="sender">Object sender</param>
        /// <param name="e">EventArgs e</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    NewsUrl = string.Format("{0}/{1}.aspx?ListCategoryName={2}&ListName={3}&{4}=",
                        SPContext.Current.Web.Url,
                        Constants.PageInWeb.DetailNews,
                        ListsName.English.CompanyCategory,
                        ListsName.English.CompanyRecord,
                        Constants.NewsId);

                    CategoryUrl = string.Format("{0}/{1}.aspx?ListCategoryName={2}&ListName={3}&Page=1&CategoryId=",
                        SPContext.Current.Web.Url,
                        Constants.PageInWeb.SubPage,
                        ListsName.English.CompanyCategory,
                        ListsName.English.CompanyRecord);

                    string companyListQuery = string.Format(@"<Where>
                                                              <And>
                                                                 <Eq>
                                                                    <FieldRef Name='{0}' LookupId='TRUE' />
                                                                    <Value Type='LookupMulti'>{1}</Value>
                                                                 </Eq>
                                                                 <And>
                                                                    <Neq>
                                                                       <FieldRef Name='Status' />
                                                                       <Value Type='Boolean'>1</Value>
                                                                    </Neq>
                                                                    <And>
                                                                       <Leq>
                                                                          <FieldRef Name='{2}' />
                                                                          <Value IncludeTimeValue='TRUE' Type='DateTime'>{3}</Value>
                                                                       </Leq>
                                                                       <And>
                                                                          <Eq>
                                                                             <FieldRef Name='{4}' />
                                                                             <Value Type='Number'>{5}</Value>
                                                                          </Eq>
                                                                          <Geq>
                                                                             <FieldRef Name='_EndDate' />
                                                                             <Value IncludeTimeValue='TRUE' Type='DateTime'>{3}</Value>
                                                                          </Geq>
                                                                       </And>
                                                                    </And>
                                                                 </And>
                                                              </And>
                                                           </Where>
                                                           <OrderBy>
                                                              <FieldRef Name='{6}' Ascending='False' />
                                                           </OrderBy>",
                                                                      FieldsName.CompanyRecord.English.CategoryName,
                                                                      WebpartParent.CompanyId, 
                                                                      FieldsName.ArticleStartDates,
                                                                      SPUtility.CreateISO8601DateTimeFromSystemDateTime(DateTime.Now), 
                                                                      FieldsName.ModerationStatus,
                                                                      Utilities.GetModerationStatus(402),
                                                                      FieldsName.ArticleStartDates);

                    uint newsNumber = 5;

                    if (!string.IsNullOrEmpty(WebpartParent.NumberOfNews))
                    {
                        newsNumber = Convert.ToUInt16(WebpartParent.NumberOfNews);
                    }
                    var companyList = Utilities.GetNewsRecords(companyListQuery, newsNumber, ListsName.English.CompanyRecord);
                    //Utilities.AddCategoryIdToTable(ListsName.English.CompanyCategory, FieldsName.CompanyRecord.English.CategoryName, ref companyList);
                    if (companyList != null && companyList.Rows.Count > 0)
                    {
                        rptCompanyList.DataSource = companyList;
                        rptCompanyList.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    Utilities.LogToUls(ex);
                }
            }
        }
    }
}
