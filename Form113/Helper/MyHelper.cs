using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Form113.Helper
{
    public static class MyHelper
    {
        /// <summary>
        /// Html.MyFieldsethelper( "Legende de la section" ) 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="legend"></param>
        /// <returns></returns>
        public static FormFieldset MyFieldsetHelper(this HtmlHelper self, string legend)
        {
            return new FormFieldset(self, legend);
        }

        #region Pagination
        private static string LiATagBuilder(string classe, string contenu)
        {
            var LI = new TagBuilder("li");
            var A = new TagBuilder("a");
            A.AddCssClass(classe);
            A.InnerHtml = contenu;
            LI.InnerHtml = A.ToString();
            return LI.ToString();
        }
        /// <summary>
        /// Html.MyPaginationChiffre( "Page Actuel" , "Nombre de Page en tout" , "Intervalle" (2))
        /// </summary>
        /// <param name="self"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageQty"></param>
        /// <param name="Intervalle"></param>
        /// <returns></returns>
        public static MvcHtmlString MyPaginationChiffre(this HtmlHelper self, int CurrentPage, int PageQty, int Intervalle = 2)
        {
            var sb = new StringBuilder();
            //var UL = new TagBuilder("ul");
            //UL.AddCssClass("pagination");
            var str = "<ul class=\"pagination\">";

            var classeClick = "pageLink";
            var classeNoClick = "pageLink notclick";

            sb.Append(str);

            int min = Intervalle;
            int max = CurrentPage + Intervalle;

            if (CurrentPage >= Intervalle + 2)
            {
                min = CurrentPage - Intervalle;
            }
            if (CurrentPage >= (PageQty - Intervalle - 1))
            {
                max = PageQty - 1;
            }

            //desactivation premier si element actuel
            if (1 != CurrentPage)
            {
                sb.Append(LiATagBuilder(classeClick, "1"));
                //UL.InnerHtml += LI.ToString();
            }
            else
            {
                //UL.InnerHtml += LI.ToString();
                sb.Append(LiATagBuilder(classeNoClick, "1"));
            }

            //Affichage element actuel et intervalle autour de lui
            for (int i = min; i <= max; i++)
            {
                if (i != CurrentPage)
                {
                    //UL.InnerHtml += LI.ToString();
                    sb.Append(LiATagBuilder(classeClick, i.ToString()));
                }
                else
                {
                    //UL.InnerHtml += LI.ToString();
                    sb.Append(LiATagBuilder(classeNoClick, i.ToString()));
                }
            }

            //desactivation dernier si element actuel
            if (1 != CurrentPage)
            {
                //UL.InnerHtml += LI.ToString();
                sb.Append(LiATagBuilder(classeClick, PageQty.ToString()));
            }
            else
            {
                //UL.InnerHtml += LI.ToString();
                sb.Append(LiATagBuilder(classeNoClick, PageQty.ToString()));
            }

            var strfin = "</ul>";
            sb.Append(strfin);

            return new MvcHtmlString(sb.ToString());
        }

        /// <summary>
        /// Html.MyPaginationChiffre( "Page Actuel" , "Nombre de Page en tout" )
        /// </summary>
        /// <param name="self"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageQty"></param>
        /// <returns></returns> 
        public static MvcHtmlString MyPaginationFleche(this HtmlHelper self, int CurrentPage, int PageQty)
        {
            var UL = new TagBuilder("ul");
            UL.AddCssClass("pagination");

            var LI = new TagBuilder("li");
            var A = new TagBuilder("a");
            A.AddCssClass("glyphicon glyphicon-step-backward");
            A.Attributes.Add("id", "FirstPage");
            LI.InnerHtml = A.ToString();
            UL.InnerHtml += LI.ToString();

            LI = new TagBuilder("li");
            A = new TagBuilder("a");
            A.AddCssClass("glyphicon glyphicon-chevron-left");
            A.Attributes.Add("id", "CurrentPage1");
            LI.InnerHtml = A.ToString();
            UL.InnerHtml += LI.ToString();

            LI = new TagBuilder("li");
            A = new TagBuilder("a");
            A.AddCssClass("glyphicon glyphicon-chevron-right");
            A.Attributes.Add("id", "CurrentPage2");
            LI.InnerHtml = A.ToString();
            UL.InnerHtml += LI.ToString();

            LI = new TagBuilder("li");
            A = new TagBuilder("a");
            A.AddCssClass("glyphicon glyphicon-step-forward");
            A.Attributes.Add("id", "LastPage");
            LI.InnerHtml = A.ToString();
            UL.InnerHtml += LI.ToString();

            return new MvcHtmlString(UL.ToString());
        }
        #endregion

        #region DropDownList CheckBoxList
        /// <summary>
        /// Html.MyDropDownListFor( model => Model."NameId" , "Liste a Lire (List<SelectListItem>)" , "id a preselectionner (0)" , "Classe (null)" , "Taille de cellule (4)") 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="self"></param>
        /// <param name="expression"></param>
        /// <param name="list"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static MvcHtmlString MyDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> self, Expression<Func<TModel, TProperty>> expression, List<SelectListItem> list, int PreSelect = 0, string classe = "width100 form-control chosen-select", int size = 4)
        {
            //exemple :
            //<select class="" id="colors" name="couleurs" size="10">
            //<option value="">Toutes couleurs</option>

            var DivTag = new TagBuilder("div");
            DivTag.AddCssClass("form-group");
            DivTag.AddCssClass(string.Format("col-sm-{0}", size));

            var Label = self.LabelFor(expression, new { @class = string.Format("col-sm-{0} control-label", size) });
            DivTag.InnerHtml = Label.ToString();

            var Select = new TagBuilder("select");
            Select.AddCssClass(classe);
            Select.Attributes.Add("id", expression.Name);
            Select.Attributes.Add("name", expression.Name);
            Select.Attributes.Add("size", "10");

            var sb = new StringBuilder();

            foreach (var item in list)
            {
                var option = new TagBuilder("option");
                if (PreSelect == int.Parse(item.Value) && PreSelect != 0)
                {
                    option.Attributes.Add("selected", "true");
                }
                option.Attributes.Add("value", item.Value);
                option.InnerHtml = item.Text.ToString();

                sb.Append(option.ToString());
            }
            Select.InnerHtml = sb.ToString();
            DivTag.InnerHtml = Select.ToString();

            return new MvcHtmlString(DivTag.ToString());
        }

        /// <summary>
        /// Html.MyDropDownListMultipleFor( model => Model."NameId" , "Liste a Lire (List<SelectListItem>)" , "Liste d'id a preselectionner (null)" , "Classe (null)" , "Taille de cellule (4)") 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="self"></param>
        /// <param name="expression"></param>
        /// <param name="list"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static MvcHtmlString MyDropDownListMultipleFor<TModel, TProperty>(this HtmlHelper<TModel> self, Expression<Func<TModel, TProperty>> expression, List<SelectListItem> list, int[] listPreSelect = null, string classe = "width100 form-control chosen-select", int size = 4)
        {
            //exemple :
            //<select class="" id="colors" name="couleurs" multiple="multiple" size="10">
            //<option value="">Toutes couleurs</option>

            var DivTag = new TagBuilder("div");
            DivTag.AddCssClass("form-group");

            var Label = self.LabelFor(expression, new { @class = string.Format("col-sm-{0} control-label", size) });
            DivTag.InnerHtml = Label.ToString();

            var Select = new TagBuilder("select");
            Select.AddCssClass(string.Format(classe + "col-sm-{0}", size));
            Select.Attributes.Add("id", expression.Name);
            Select.Attributes.Add("name", expression.Name);
            Select.Attributes.Add("multiple", "true");
            Select.Attributes.Add("size", "10");

            var sb = new StringBuilder();

            foreach (var item in list)
            {
                var option = new TagBuilder("option");
                if (listPreSelect.Contains(int.Parse(item.Value)) && listPreSelect != null)
                {
                    option.Attributes.Add("selected", "true");
                }
                option.Attributes.Add("value", item.Value);
                option.InnerHtml = item.Text.ToString();

                sb.Append(option.ToString());
            }
            Select.InnerHtml = sb.ToString();
            DivTag.InnerHtml = Select.ToString();

            return new MvcHtmlString(DivTag.ToString());
        }

        /// <summary>
        /// Html.MyDropDownListFor( model => Model."NameId" , "Liste a Lire (List<SelectListItem>)" , "id a preselectionner (0)" , "Classe (null)" , "Taille de cellule (4)") 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="self"></param>
        /// <param name="expression"></param>
        /// <param name="list"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static MvcHtmlString MyCheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> self, Expression<Func<TModel, TProperty>> expression, List<SelectListItem> list, int PreSelect = 0, string classe = "col-sm-3", int size = 4)
        {
            var DivTag = new TagBuilder("div");
            DivTag.AddCssClass("form-group");


            var sb = new StringBuilder();

            foreach (var item in list)
            {

                //<label for="@g.ItemId" class="list-group">@g.ItemLabel</label>

                var Label = self.LabelFor(expression, new { @class = "list - group" });
                DivTag.InnerHtml = Label.ToString();
                var LI = new TagBuilder("li");
                LI.AddCssClass(classe);
                var input = new TagBuilder("input");
                if (PreSelect == int.Parse(item.Value) && PreSelect != 0)
                {
                    input.Attributes.Add("checked", "true");
                }
                input.Attributes.Add("type", "checkbox");
                input.Attributes.Add("id", item.Value);
                input.Attributes.Add("name", expression.Name);
                input.Attributes.Add("value", item.Value);

                input.InnerHtml = item.Text.ToString();
                LI.InnerHtml = Label.ToString() + input.ToString();

                sb.Append(LI.ToString());
            }
            DivTag.InnerHtml = sb.ToString();

            return new MvcHtmlString(DivTag.ToString());
        }
        #endregion

        #region TextBox Password
        /// <summary>
        /// Html.MyTextBoxFor( model => Model."NameId" , "Taille de cellule (4)") 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="self"></param>
        /// <param name="expression"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static MvcHtmlString MyTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> self, Expression<Func<TModel, TProperty>> expression, int size = 4)
        {
            var BR = new TagBuilder("br/");

            var divTag = new TagBuilder("div");
            divTag.AddCssClass("form-group");

            var Label = self.LabelFor(expression, new { @class = string.Format("col-sm-{0} control-label", size) });
            divTag.InnerHtml = Label.ToString();

            var divInnerTag = new TagBuilder("div");
            divInnerTag.AddCssClass(string.Format("col-sm-{0}", 12 - size));

            var TexteBox = self.TextBoxFor(expression, new { @class = "form-control" });
            var ValidationMessage = self.ValidationMessageFor(expression, "", new { @class = "text-danger" });

            divInnerTag.InnerHtml = TexteBox.ToString();
            divInnerTag.InnerHtml += ValidationMessage.ToString();

            divTag.InnerHtml += divInnerTag.ToString() + BR.ToString();
            return new MvcHtmlString(divTag.ToString());
            /*
            @Html.EditorFor(model => model.Prenom, new { htmlAttributes = new { @class = "form-control" } })
            */
        }

        /// <summary>
        /// Html.MyPasswordFor( model => Model."NameId" , "Taille de cellule (4)") 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="self"></param>
        /// <param name="expression"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static MvcHtmlString MyPasswordFor<TModel, TProperty>(this HtmlHelper<TModel> self, Expression<Func<TModel, TProperty>> expression, int size = 4)
        {
            var BR = new TagBuilder("br/");

            var divTag = new TagBuilder("div");
            divTag.AddCssClass("form-group");

            var Label = self.LabelFor(expression, new { @class = string.Format("col-sm-{0} control-label", size) });
            divTag.InnerHtml = Label.ToString();

            var divInnerTag = new TagBuilder("div");
            divInnerTag.AddCssClass(string.Format("col-sm-{0}", 12 - size));

            var TexteBox = self.PasswordFor(expression, new { @class = "form-control" });
            var ValidationMessage = self.ValidationMessageFor(expression, "", new { @class = "text-danger" });

            divInnerTag.InnerHtml = TexteBox.ToString() + ValidationMessage.ToString();

            divTag.InnerHtml += divInnerTag.ToString() + BR.ToString();
            return new MvcHtmlString(divTag.ToString());
            /*
            @Html.EditorFor(model => model.Prenom, new { htmlAttributes = new { @class = "form-control" } })
            */
        }
        #endregion


        /// <summary>
        /// Html.MyCarousele( "Page Actuel" , "Nombre de Page en tout" , "Intervalle" (2))
        /// </summary>
        /// <param name="self"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageQty"></param>
        /// <param name="Intervalle"></param>
        /// <returns></returns>       
        //Besoin de l'entity framework

        //public static MvcHtmlString MyCarousele(this HtmlHelper self, int CurrentPage, int PageQty, int Intervalle = 2)
        //{
        //    var sb = new StringBuilder();
        //    //var UL = new TagBuilder("ul");
        //    //UL.AddCssClass("pagination");
        //    var str = "<ul class=\"pagination\">";

        //    var classeClick = "pageLink";
        //    var classeNoClick = "pageLink notclick";

        //    sb.Append(str);

        //    int min = Intervalle;
        //    int max = CurrentPage + Intervalle;

        //    if (CurrentPage >= Intervalle + 2)
        //    {
        //        min = CurrentPage - Intervalle;
        //    }
        //    if (CurrentPage >= (PageQty - Intervalle - 1))
        //    {
        //        max = PageQty - 1;
        //    }

        //    //desactivation premier si element actuel
        //    if (1 != CurrentPage)
        //    {
        //        sb.Append(LiATagBuilder(classeClick, "1"));
        //        //UL.InnerHtml += LI.ToString();
        //    }
        //    else
        //    {
        //        //UL.InnerHtml += LI.ToString();
        //        sb.Append(LiATagBuilder(classeNoClick, "1"));
        //    }

        //    //Affichage element actuel et intervalle autour de lui
        //    for (int i = min; i <= max; i++)
        //    {
        //        if (i != CurrentPage)
        //        {
        //            //UL.InnerHtml += LI.ToString();
        //            sb.Append(LiATagBuilder(classeClick, i.ToString()));
        //        }
        //        else
        //        {
        //            //UL.InnerHtml += LI.ToString();
        //            sb.Append(LiATagBuilder(classeNoClick, i.ToString()));
        //        }
        //    }

        //    //desactivation dernier si element actuel
        //    if (1 != CurrentPage)
        //    {
        //        //UL.InnerHtml += LI.ToString();
        //        sb.Append(LiATagBuilder(classeClick, PageQty.ToString()));
        //    }
        //    else
        //    {
        //        //UL.InnerHtml += LI.ToString();
        //        sb.Append(LiATagBuilder(classeNoClick, PageQty.ToString()));
        //    }

        //    var strfin = "</ul>";
        //    sb.Append(strfin);

        //    return new MvcHtmlString(sb.ToString());
        //}

        /*
         <div id="@Model.IdVoiture" class="carousel slide" data-ride="carousel">
                    <div class="carousel-inner" role="listbox">
                        @{
                            int i = 0;
                            foreach (var item in Model.Photos)
                            {
                                if (i == 0)
                                {
                                    <div class="item active">
                                        <img src="~/Uploads/@item.PhotoName" class="MonAffichageImage" alt="L'image de la voiture n'est pas disponible" />
                                    </div>
                                }
                                else
                                {
                                    <div class="item">
                                        <img src="~/Uploads/@item.PhotoName" class="MonAffichageImage" alt="L'image de la voiture n'est pas disponible" />
                                    </div>
                                }
                                i++;
                            }}
                    </div>
                    <a class="left carousel-control" href="#@Model.IdVoiture" role="button" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="right carousel-control" href="#@Model.IdVoiture" role="button" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
         */
    }
}