﻿using System.Collections.Generic;
using System.Linq;

namespace JqueryTreeview.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UpperCategoryId { get; set; }

        // Special properties for treeview
        public bool Selectable { get; set; }
        public bool HasChild
        {
            get
            {
                var listOfCategories = Category.LongGetAllCategoriesAsFlatList();
                return listOfCategories.Any(c => this.Id.Equals(c.UpperCategoryId));
            }
        }


        public static IEnumerable<Category> ShortGetCategories(int upperId = 0)
        {
            var listOfCategories = Category.ShortGetAllCategoriesAsFlatList();

            return listOfCategories.Where(c => upperId.Equals(c.UpperCategoryId));
        }

        private static IEnumerable<Category> ShortGetAllCategoriesAsFlatList()
        {
            var listOfCategories = new List<Category>
                {
                    new Category
                        {
                            Id = 112131,
                            Name = "Best Books of the Year So Far",
                            Description = "Top 20 Editors' Picks, Mystery, Thriller & Suspense, Teens and more",
                            UpperCategoryId = 1121
                        },
                    new Category
                        {
                            Id = 1121,
                            Name = "Books",
                            Description = "Paper books",
                            UpperCategoryId = 11
                        },
                    new Category
                        {
                            Id = 11,
                            Name = "Book Store",
                            Description = "All the best salers are here"
                        },
                };

            return listOfCategories;
        }


        public static IEnumerable<Category> LongGetCategories(int upperId = 0)
        {
            var listOfCategories = Category.LongGetAllCategoriesAsFlatList();

            return listOfCategories.Where(c => upperId.Equals(c.UpperCategoryId));
        }

        private static IEnumerable<Category> LongGetAllCategoriesAsFlatList()
        {
            var listOfCategories = new List<Category>
                {
                    new Category
                        {
                            Id = 112131,
                            Name = "Best Books of the Year So Far",
                            Description = "Top 20 Editors' Picks, Mystery, Thriller & Suspense, Teens and more",
                            UpperCategoryId = 1121
                        },
                    new Category
                        {
                            Id = 112132,
                            Name = "Fall Reading",
                            Description = "New Fiction, Fall Blockbusters, Editors' Picks and more",
                            UpperCategoryId = 1121
                        },
                    new Category
                        {
                            Id = 11213241,
                            Name = "The Casual Vacancy",
                            Description = "When Barry Fairbrother dies unexpectedly in his early forties",
                            UpperCategoryId = 112132
                        },
                    new Category
                        {
                            Id = 112133,
                            Name = "Best Books of the Month",
                            Description = "The End of Your Life Book Club by Will Schwalbe, Live by Night by Dennis Lehane, Back to Blood by Tom Wolfe and more",
                            UpperCategoryId = 1121
                        },
                    new Category
                        {
                            Id = 1121,
                            Name = "Books",
                            Description = "Paper books",
                            UpperCategoryId = 11
                        },
                    new Category
                        {
                            Id = 11,
                            Name = "Book Store",
                            Description = "All the best salers are here"
                        },
                    new Category
                        {
                            Id = 112134,
                            Name = "Textbooks",
                            Description = "Up to 30% Off New and Up to 90% Off Used Textbooks, Up to 70% Back for Your Used Textbooks, Amazon Student and more",
                            UpperCategoryId = 1121
                        },
                    new Category
                        {
                            Id = 112135,
                            Name = "Award Winners",
                            Description = "Pulitzer Prizes, Edgar Awards, James Beard Foundation Book Awards and more",
                            UpperCategoryId = 1121
                        },
                    new Category
                        {
                            Id = 112136,
                            Name = "Children's Books",
                            Description = "Essential Books for Children, Children's Book Awards, Amazon Kids and more",
                            UpperCategoryId = 1121
                        },
                    new Category
                        {
                            Id = 1122,
                            Name = "eBooks",
                            Description = "Eletronnic versions of all your favorities books",
                            UpperCategoryId = 11
                        },
                    new Category
                        {
                            Id = 112231,
                            Name = "Best Books of the Month",
                            Description = "The End of Your Life Book Club by Will Schwalbe, Live by Night by Dennis Lehane, Back to Blood by Tom Wolfe and more",
                            UpperCategoryId = 1122
                        },
                    new Category
                        {
                            Id = 112232,
                            Name = "Best Books of the Year So Far",
                            Description = "Top 20 Editors' Picks, Mystery, Thriller & Suspense, Teens and more",
                            UpperCategoryId = 1122
                        },
                    new Category
                        {
                            Id = 1123,
                            Name = "Pre-Owned",
                            Description = "Used books",
                            UpperCategoryId = 11
                        },
                    new Category
                        {
                            Id = 112331,
                            Name = "Award Winners",
                            Description = "Pulitzer Prizes, Edgar Awards, James Beard Foundation Book Awards and more",
                            UpperCategoryId = 1123
                        },
                    new Category
                        {
                            Id = 112333,
                            Name = "Best Books of the Month",
                            Description = "The End of Your Life Book Club by Will Schwalbe, Live by Night by Dennis Lehane, Back to Blood by Tom Wolfe and more",
                            UpperCategoryId = 1123
                        },
                    new Category
                        {
                            Id = 112332,
                            Name = "Fall Reading",
                            Description = "New Fiction, Fall Blockbusters, Editors' Picks and more",
                            UpperCategoryId = 1123
                        },
                    new Category
                        {
                            Id = 13,
                            Name = "Home, Garden & Tools",
                            Description = "Everything for your well living"
                        },
                    new Category
                        {
                            Id = 1221,
                            Name = "Electronics",
                            Description = "TV & Video, Home Audio & Theater",
                            UpperCategoryId = 12
                        },
                    new Category
                        {
                            Id = 1222,
                            Name = "Computers",
                            Description = "Laptops, Tablets & Netbooks",
                            UpperCategoryId = 12
                        },
                    new Category
                        {
                            Id = 12,
                            Name = "Electronics & Computers",
                            Description = "All the new stuff right here",
                            Selectable = true
                        },
                    new Category
                        {
                            Id = 122231,
                            Name = "Laptop & Tablet Categories",
                            Description = "Best Sellers, Hot New Releases and Most Gifted",
                            UpperCategoryId = 1222
                        },
                    new Category
                        {
                            Id = 11213341,
                            Name = "The End of Your Life Book Club by Will Schwalbe",
                            Description = "That’s the question Will Schwalbe asks his mother, Mary Anne, as they sit in the waiting room of the Memorial Sloan-Kettering Cancer Center. In 2007, Mary Anne returned from a humanitarian trip to Pakistan and Afghanistan suffering from what her doctors believed was a rare type of hepatitis. Months later she was diagnosed with a form of advanced pancreatic cancer, which is almost always fatal, often in six months or less",
                            UpperCategoryId = 112133,
                            Selectable = true
                        }
                };

            return listOfCategories;
        }
    }
}