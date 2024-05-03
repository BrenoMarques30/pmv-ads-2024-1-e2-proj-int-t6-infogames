using Microsoft.AspNetCore.Html;
using System.Text;

namespace InfoGames.Middlewares {
    public class Paginacao {
        private readonly Func<int, int, string, string> _createNewBasket;

        public Paginacao(Func<int, int, string, string> createNewBasket) {
            _createNewBasket = createNewBasket;
        }

        public HtmlString GeneratePagination(int page, int pageSize, string searchTerm, int totalPages) {
            var pagination = new StringBuilder();

            pagination.Append("<div class=\"row\">");
            pagination.Append("<div>");

            if (page > 4) {
                pagination.Append($"<a href=\"{_createNewBasket(1, pageSize, searchTerm)}\">1 </a>");
                pagination.Append("<span>... </span>");
            }

            for (int i = Math.Max(1, page - 3); i <= Math.Min(page + 3, totalPages); i++) {
                if (i == page) {
                    pagination.Append($"<span>{i} </span>");
                } else {
                    pagination.Append($"<a href=\"{_createNewBasket(i, pageSize, searchTerm)}\">{i} </a>");
                }
            }

            if (page < totalPages - 3) {
                pagination.Append("<span>... </span>");
                pagination.Append($"<a href=\"{_createNewBasket(totalPages, pageSize, searchTerm)}\">{totalPages}</a>");
            }

            pagination.Append("</div>");
            pagination.Append("</div>");

            return new HtmlString(pagination.ToString());
        }
    }

}
