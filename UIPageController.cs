using System.Collections.Generic;
using UnityEngine;

namespace BluePixel.UISystem
{
    public class UIPageController : MonoBehaviour
    {
        private Stack<UIPage> _pageHistory = new();

        public void AddPage(UIPage page)
        {
            if (page == null) return;
            if (_pageHistory.Count > 0 && _pageHistory.Peek() == page) return;

            if (_pageHistory.Count > 0)
            {
                var prevPage = _pageHistory.Peek();
                if (prevPage.DisableWhenNextPageOpens)
                    prevPage.Close();
            }

            _pageHistory.Push(page);
            page.Open();
        }

        public void RemovePage()
        {
            if (_pageHistory.Count <= 0) return;

            var currentPage = _pageHistory.Pop();
            currentPage.Close();

            if (_pageHistory.Count > 0)
            {
                var prevPage = _pageHistory.Peek();
                if (prevPage.DisableWhenNextPageOpens)
                    prevPage.Open();
            }
        }

        public void RemoveAllPages()
        {
            while (_pageHistory.Count > 0)
            {
                //var currentPage = _pageHistory.Pop();
                //currentPage.Close();

                _pageHistory.Pop().Close();
            }
        }

        public void RemoveAllAndAddPage(UIPage page)
        {
            RemoveAllPages();
            AddPage(page);
        }
    }
}
