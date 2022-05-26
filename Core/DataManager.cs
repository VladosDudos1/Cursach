using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class DataManager
    {
        public static List<Title> GetTitles()
        {
            return BdConnection.animeBase.Title.ToList();
        }
        public static List<User> GetUsers()
        {
            return BdConnection.animeBase.User.ToList();
        }
        public static void AddTitleToList(Title title, int idList)
        {
            var allList = BdConnection.animeBase.UserLists.ToList();
            try
            {
                var ul = new UserLists();
                ul.idTitle = title.id;
                ul.episodes = title.episodes;
                ul.listType = idList;
                BdConnection.animeBase.UserLists.Add(ul);   
            }
            catch (Exception)
            {
                ChangeTitleListType(title, idList);
            }
            BdConnection.animeBase.SaveChanges();
        }

        public static List<UserLists> GetTitlesWithList()
        {
            return BdConnection.animeBase.UserLists.ToList();
        }

        public static int GetTitleWithList(int idTitle)
        {
            var title = BdConnection.animeBase.UserLists.Find(idTitle);
            return (title == null) ? 0 : title.listType;
        }
        public static void AddTitleById(int idTitle, List<Title> list, List<Title> bigList)
        {
            foreach (var i in bigList)
            {
                if (i.id == idTitle)
                {
                    list.Add(i);
                }
            }
            BdConnection.animeBase.SaveChanges();
        }
        public static void DeleteTitleFromList(Title title)
        {
            foreach (var i in GetTitlesWithList())
            {
                if (i.idTitle == title.id)
                {
                    BdConnection.animeBase.UserLists.Remove(i);
                }
            }
            BdConnection.animeBase.SaveChanges();
        }
        public static void ChangeTitleListType(Title title, int idList)
        {
            foreach (UserLists i in GetTitlesWithList())
            {
                if (i.idTitle == title.id)
                {
                    i.listType = idList;
                    BdConnection.animeBase.UserLists.FirstOrDefault();
                    BdConnection.animeBase.SaveChanges();
                    break;
                }
            }
        }
        public static Title TitleById(int idTitle)
        {
            foreach (var i in GetTitles())
            {
                if (i.id == idTitle)
                {
                    return i;
                }
            }
            return new Title();
        }
        public static UserLists UlById(int idUl)
        {
            foreach (var i in BdConnection.animeBase.UserLists.ToList())
            {
                if (i.listType == idUl)
                {
                    return i;
                }
            }
            return new UserLists();
        }
        public static List<ListType> GetListTypes()
        {
            var listBase = new List<ListType>();

            foreach (var i in BdConnection.animeBase.ListType.ToList())
            {
                var lt = new ListType();
                lt.id = i.id;
                lt.name = i.name;
                listBase.Add(lt);
            }
            
            return listBase; 
        }
    }
}
