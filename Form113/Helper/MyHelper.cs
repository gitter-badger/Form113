using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Form113.Models;
using System.Web.Helpers;

namespace Form113.Helper
{
    public static class MyHelper
    {

        //VALIDER
        #region FieldSet
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
        #endregion

        //VALIDER
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

        //VALIDER
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

        //VALIDER
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
        public static MvcHtmlString MyDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> self, Expression<Func<TModel, TProperty>> expression, List<SelectListItem> list, int PreSelect = 0, string classe = "width100 form-control chosen-select ", int size = 4)
        {
            //exemple :
            //<select class="" id="colors" name="couleurs" size="10">
            //<option value="">Toutes couleurs</option>

            MemberExpression member = expression.Body as MemberExpression;

            var DivTag = new TagBuilder("div");
            DivTag.AddCssClass("form-group");
            DivTag.Attributes.Add("id", "div" + member.Member.Name);

            var Label = self.LabelFor(expression, new { @class = string.Format("col-sm-{0} control-label", size) });
            DivTag.InnerHtml = Label.ToString();


            var Select = new TagBuilder("select");
            Select.AddCssClass(string.Format(classe + "col-sm-{0}", size));
            Select.Attributes.Add("id", member.Member.Name);
            Select.Attributes.Add("name", member.Member.Name);

            var sb = new StringBuilder();
            if (list != null)
            {
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
            }
            Select.InnerHtml = sb.ToString();
            DivTag.InnerHtml += Select.ToString();

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
        public static MvcHtmlString MyDropDownListMultipleFor<TModel, TProperty>(this HtmlHelper<TModel> self, Expression<Func<TModel, TProperty>> expression, List<SelectListItem> list, int[] listPreSelect = null, string classe = "width100 form-control chosen-select ", int size = 4)
        {
            //exemple :
            //<select class="" id="colors" name="couleurs" multiple="multiple" size="10">
            //<option value="">Toutes couleurs</option>
            MemberExpression member = expression.Body as MemberExpression;

            var DivTag = new TagBuilder("div");
            DivTag.AddCssClass("form-group");
            DivTag.Attributes.Add("id", "div" + member.Member.Name);

            var Label = self.LabelFor(expression, new { @class = string.Format("col-sm-{0} control-label", size) });
            DivTag.InnerHtml = Label.ToString();


            var Select = new TagBuilder("select");
            Select.AddCssClass(string.Format(classe + "col-sm-{0}", size));
            Select.Attributes.Add("id", member.Member.Name);
            Select.Attributes.Add("name", member.Member.Name);
            Select.Attributes.Add("multiple", "true");

            var sb = new StringBuilder();

            if (list != null)
            {
                foreach (var item in list)
                {
                    var option = new TagBuilder("option");
                    if (listPreSelect != null)
                    {
                        if (listPreSelect.Contains(int.Parse(item.Value)))
                        {
                            option.Attributes.Add("selected", "true");
                        }
                    }
                    option.Attributes.Add("value", item.Value);
                    option.InnerHtml = item.Text.ToString();

                    sb.Append(option.ToString());
                }
            }
            Select.InnerHtml = sb.ToString();
            DivTag.InnerHtml += Select.ToString();

            return new MvcHtmlString(DivTag.ToString());
        }

        /// <summary>
        /// Html.MyCheckBoxListFor( model => Model."NameId" , "Liste a Lire (List<CheckBoxItem>)" , "liste d'id a preselectionner en long[]" , "Classe (null)" , "Taille de cellule (4)") 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="self"></param>
        /// <param name="expression"></param>
        /// <param name="list"></param>
        /// <param name="PreSelect"></param>
        /// <param name="classe"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static MvcHtmlString MyCheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> self, Expression<Func<TModel, TProperty>> expression, List<CheckBoxItem> list, long[] ListPreSelect = null, string classe = "col-sm-3", int size = 4)
        {
            MemberExpression member = expression.Body as MemberExpression;

            var DivTag = new TagBuilder("div");
            DivTag.AddCssClass("form-group");
            DivTag.Attributes.Add("id", "div" + member.Member.Name);


            var sb = new StringBuilder();

            int i = 0;

            if (list != null)
            {
                foreach (CheckBoxItem item in list)
                {

                    //<label for="@g.ItemId" class="list-group">@g.ItemLabel</label>

                    var Label = new TagBuilder("label");
                    Label.AddCssClass("list - group");
                    Label.Attributes.Add("for", item.ItemLabel);
                    Label.InnerHtml = item.ItemLabel;
                    DivTag.InnerHtml = Label.ToString();

                    var LI = new TagBuilder("li");
                    LI.AddCssClass(classe);
                    var input = new TagBuilder("input");

                    if (ListPreSelect != null)
                    {
                        if (ListPreSelect.Contains(long.Parse(item.ItemId.ToString())))
                        {
                            input.Attributes.Add("checked", "true");
                        }
                    }
                    input.Attributes.Add("type", "checkbox");
                    input.Attributes.Add("id", item.ItemId.ToString());
                    input.Attributes.Add("name", member.Member.Name);
                    input.Attributes.Add("value", item.ItemId.ToString());

                    LI.InnerHtml = Label.ToString() + input.ToString();

                    sb.Append(LI.ToString());
                    i++;
                }
            }
            DivTag.InnerHtml = sb.ToString();

            return new MvcHtmlString(DivTag.ToString());
        }
        #endregion

        //VALIDER
        #region Carousel
        private static string ButtonPrecedentSuivantCarousele(string ID)
        {
            var sb = new StringBuilder();

            var A = new TagBuilder("a");
            A.AddCssClass("left carousel-control");
            A.Attributes.Add("href", "#" + ID);
            A.Attributes.Add("role", "button");
            A.Attributes.Add("data-slide", "prev");

            var span = new TagBuilder("span");
            span.AddCssClass("glyphicon glyphicon-chevron-left");
            span.Attributes.Add("aria-hidden", "true");
            A.InnerHtml = span.ToString();

            span = new TagBuilder("span");
            span.AddCssClass("sr-only");
            span.InnerHtml = "Previous";
            A.InnerHtml += span.ToString();

            sb.Append(A.ToString());

            A = new TagBuilder("a");
            A.AddCssClass("right carousel-control");
            A.Attributes.Add("href", "#" + ID);
            A.Attributes.Add("role", "button");
            A.Attributes.Add("data-slide", "next");

            span = new TagBuilder("span");
            span.AddCssClass("glyphicon glyphicon-chevron-right");
            span.Attributes.Add("aria-hidden", "true");
            A.InnerHtml = span.ToString();

            span = new TagBuilder("span");
            span.AddCssClass("sr-only");
            span.InnerHtml = "Next";
            A.InnerHtml += span.ToString();

            sb.Append(A.ToString());

            return sb.ToString();
        }
        /// <summary>
        /// Html.MyCarousel( "Liste de Photos" , "Id Carousele", "classe carousel", "classe image")
        /// </summary>
        /// <param name="self"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageQty"></param>
        /// <param name="Intervalle"></param>
        /// <returns></returns>       
        public static MvcHtmlString MyCarousel(this HtmlHelper self, List<Photos> ListPhotos, int Id, string classe = "carousel slide", string classeImg = "MonAffichageImage")
        {
            var sb = new StringBuilder();

            var divTag = new TagBuilder("div");
            divTag.AddCssClass(classe);
            divTag.Attributes.Add("id", Id.ToString());
            divTag.Attributes.Add("data-ride", "carousel");

            var divIntern = new TagBuilder("div");
            divIntern.AddCssClass("carousel-inner");
            divIntern.Attributes.Add("role", "listbox");

            int i = 0;
            foreach (var item in ListPhotos)
            {
                if (i == 0)
                {
                    var divPhoto = new TagBuilder("div");
                    divPhoto.AddCssClass("item active");

                    var img = new TagBuilder("img");
                    img.AddCssClass(classeImg);
                    img.Attributes.Add("src", "/Uploads/" + item.PhotoName);
                    img.Attributes.Add("alt", "L'image du Produit est indisponible");

                    divPhoto.InnerHtml = img.ToString();
                    sb.Append(divPhoto.ToString());
                }
                else
                {
                    var divPhoto = new TagBuilder("div");
                    divPhoto.AddCssClass("item");

                    var img = new TagBuilder("img");
                    img.AddCssClass(classeImg);
                    img.Attributes.Add("src", "/Uploads/" + item.PhotoName);
                    img.Attributes.Add("alt", "L'image du Produit est indisponible");

                    divPhoto.InnerHtml = img.ToString();
                    sb.Append(divPhoto.ToString());
                }
                i++;
            }

            divIntern.InnerHtml = sb.ToString();

            string button = ButtonPrecedentSuivantCarousele(Id.ToString());
            divTag.InnerHtml = divIntern.ToString() + button;

            return new MvcHtmlString(divTag.ToString());
        }
        #endregion

        public static MvcHtmlString ImageHelp(this HtmlHelper self, string imgname)
        {
            string dir = "/Uploads/";
            TagBuilder image = new TagBuilder("img");
            image.MergeAttribute("src", dir + imgname);
            image.MergeAttribute("alt", "Image non disponible");
            return new MvcHtmlString(image.ToString());
        }

        // En cours de travail
        #region PhotoClickable
        public static MvcHtmlString ActionImage(this HtmlHelper helper, string controller,string action,Object parameters, string src, string alt="",string title="")
        {
            TagBuilder tagBuilder = new TagBuilder("img");
            UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            String url = urlHelper.Action(action, controller, parameters);
            string imgUrl = urlHelper.Content(src);
            string image = "";
            StringBuilder html = new StringBuilder();

            // Construction du tag de l'image
            tagBuilder.MergeAttribute("src", imgUrl);
            tagBuilder.MergeAttribute("alt", alt);
            tagBuilder.MergeAttribute("title", title);
            tagBuilder.AddCssClass("img-responsive");
            image = tagBuilder.ToString(TagRenderMode.SelfClosing);
            html.Append("<a href=\"");
            html.Append(url);
            html.Append("\">");
            html.Append(image);
            html.Append("</a>");
            return MvcHtmlString.Create(html.ToString());

        }
        #endregion
    }
}