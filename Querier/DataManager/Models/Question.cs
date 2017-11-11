﻿using System;
using System.Collections.Generic;
using System.Data;

namespace DataManager
{
    public class Question
    {
        public int UserID { get; set; }
        public int QueryNumber { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public List<Answer> Answers;

        public Question()
        {
            UserID = 0;
            QueryNumber = 0;
            Number = 0;
            Order = 0;

            Answers = new List<Answer>();
        }

        public Question(DataRow dr)
        {
            bool IsFullLoad = (dr.Table.Columns.Contains("userID"));

            if (dr["number"] != null) Number = int.Parse(dr["number"].ToString());
            if (dr["name"] != null) Name = dr["name"].ToString();
            if (dr["ordinality"] != null) Order = int.Parse(dr["ordinality"].ToString());

            if (IsFullLoad)
            {
                if (dr["userID"] != null) UserID = int.Parse(dr["UserID"].ToString());
                if (dr["queryNumber"] != null) QueryNumber = int.Parse(dr["queryNumber"].ToString());

                Answers = QuestionData.GetAnswers(UserID, QueryNumber, Number); 
            }
        }

    }
}
