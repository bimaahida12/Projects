<%@ Page Title="Category" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="GoldstoneForum.Category" %>

<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <h3>Category: <asp:Literal ID="CategoryTitle" Text="" runat="server" /></h3>
    <asp:ListView runat="server" ID="ListViewCategories" DataKeyNames="Id" SelectMethod="ListViewCategories_GetData"
        ItemPlaceholderID="CategoryNameLabel"
        ItemType="GoldstoneForum.Models.Question">
        <LayoutTemplate>
            <div runat="server">
                <div runat="server" id="CategoryNameLabel"></div>
                 <ul class="pager">
                <asp:DataPager ID="CategoriesPager" runat="server" PagedControlID="ListViewCategories" PageSize="10">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonCssClass="btn" ButtonType="Button" ShowPreviousPageButton="true" ShowNextPageButton="false" />
                        <asp:NumericPagerField CurrentPageLabelCssClass="btn disabled" NumericButtonCssClass="btn"/>
                        <asp:NextPreviousPagerField ButtonCssClass="btn" ButtonType="Button" ShowNextPageButton="true" ShowPreviousPageButton="false" />
                    </Fields>
                </asp:DataPager></ul>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="well well-sm">
                <div class="voting">
                    <asp:ImageButton ImageUrl="~/img/upvote.png" ImageAlign="Middle" Text="Vote"
                        CssClass="votePositive" runat="server" OnCommand="Vote_Command"
                        CommandName="Vote" CommandArgument="<%# Item.Id %>" Visible='<%# CanUserVoteOnAnswer(Item.Id) %>' />
                    <asp:ImageButton ImageUrl="~/img/downvote.png" ImageAlign="Middle" Text="Unvote"
                        CssClass="voteNegative" runat="server" OnCommand="Vote_Command"
                        CommandName="Unvote" CommandArgument="<%# Item.Id %>" Visible="<%# CanUserUnVoteOnAnswer(Item.Id) %>" />

                    <div runat="server" class="list-group-item"><span class="badge"><%# Item.Votes.Count%></span> votes</div>
                    <div runat="server" class="list-group-item"><span class="badge"><%# Item.Answers.Count %></span> answers</div>
                </div>
                <div class="questionBox">
                <div runat="server" class="col-md-8">
                    <asp:HyperLink Font-Size="X-Large" runat="server" Text="<%#: Item.Title %>" CssClass="question-title"
                                NavigateUrl='<%#"~/QuestionForm.aspx?id=" + Item.Id %>' />
                </div>
                <div runat="server" class="col-md-8">
                            Asked on <span runat="server" class="question-date"><%# Item.DatePosted.ToString() %></span>
                    in
                        <asp:HyperLink runat="server" CssClass="question-category"
                            NavigateUrl='<%#"Category.aspx?id=" + Item.Category.Id %>' Text="<%#: Item.Category.Name %>" />
                    by <span runat="server" class="question-author"><%#: Item.User.UserName %> </span>
                </div>
            </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
