using MyBatisNet.DAL;
using MyBatisNet.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyBatisNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        log4net.ILog log = log4net.LogManager.GetLogger("Form1");

        private void Form1_Load(object sender, EventArgs e)
        {
            //查所有记录
            var models = BaseDA.QueryForList<User>("SelectAllUser");
            foreach (var item in models)
            {
                ShowUser(item);
            }


            //插单条
            bool isCheck = BaseDA.Insert("InsertUser", new User()
            {
                VC_ID = "Mark",
                VC_USERNAME = "123",
                VC_USERPASS = "Mark",
                VC_DEPNAME = "系统",
                VC_ISADMIN = "1",
                VC_CID = "Mark",
                D_CDATE = DateTime.Now,
                VC_MID = "Mark",
                D_MDATE = DateTime.Now,
                VC_ISDEL = "0",
            });
            Debug.WriteLine("录入是否成功？" + isCheck);
            log.Info("录入是否成功？" + isCheck);


            //插多条
            bool isCheck1 = BaseDA.InsertForList("InsertUser", new List<User>()
            {
                new User(){
                     VC_ID = "Mark3",
                     VC_USERNAME = "123",
                     VC_USERPASS = "Mark",
                     VC_DEPNAME = "系统",
                     VC_ISADMIN = "1",
                     VC_CID = "Mark",
                     D_CDATE = DateTime.Now,
                     VC_MID = "Mark",
                     D_MDATE = DateTime.Now,
                     VC_ISDEL = "0",
                },
                new User(){
                     VC_ID = "Mark2",
                     VC_USERNAME = "123",
                     VC_USERPASS = "Mark",
                     VC_DEPNAME = "系统",
                     VC_ISADMIN = "1",
                     VC_CID = "Mark",
                     D_CDATE = DateTime.Now,
                     VC_MID = "Mark",
                     D_MDATE = DateTime.Now,
                     VC_ISDEL = "0",
                },
            });
            Debug.WriteLine("录入是否成功？" + isCheck1);
            log.Info("录入是否成功？" + isCheck1);


            //查单条记录
            var model = BaseDA.Query<User,string>("SelectByUserId", "Mark");
            ShowUser(model);

            //查多条记录
            var modelswhere = BaseDA.QueryWhere<User, IList<string>>("SelectByUserIds", new List<string>() { "Mark", "Mark2", "Mark3" });
            foreach (var item in modelswhere)
            {
                ShowUser(item);
            }

            ////修改记录
            //if (model != null)
            //{
            //    model.VC_USERNAME = (new Random().Next(0, 99999999)).ToString().PadLeft(10, '0');
            //    int updateResult = BaseDA.Update<User>("UpdateUser", model);
            //    Debug.WriteLine("update影响行数:" + updateResult);
            //    log.Info("update影响行数:" + updateResult);
            //}

            ////修改多条记录
            if (modelswhere.Any())
            {
                IList<User> lisUser = modelswhere;
                foreach (var item in lisUser)
                {
                    item.VC_USERNAME = (new Random().Next(0, 99999999)).ToString().PadLeft(10, '0');
                }
                int updateResult = BaseDA.UpdateForList("UpdateUser", lisUser);
                Debug.WriteLine("update影响行数:" + updateResult);
                log.Info("update影响行数:" + updateResult);
            }

            ////删除记录
            //int deleteResult = BaseDA.Delete("DeleteUserById", "Mark");
            //Debug.WriteLine("delete影响行数:" + deleteResult);
            //log.Info("delete影响行数:" + deleteResult);

            //删除多条记录
            int deleteResults = BaseDA.DeleteForList("DeleteUsersByIds", new List<string>() { "Mark","Mark2", "Mark3"});
            Debug.WriteLine("delete影响行数:" + deleteResults);
            log.Info("delete影响行数:" + deleteResults);
        }

        void ShowUser(User user)
        {
            if (user == null) return;
            Debug.WriteLine(DateTime.Now + "：" + string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                user.VC_ID, user.VC_USERNAME, user.VC_USERPASS, user.VC_DEPNAME, user.VC_ISADMIN, user.VC_CID, user.D_CDATE, user.VC_MID, user.D_MDATE, user.VC_ISDEL));
            log.Info(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                user.VC_ID, user.VC_USERNAME, user.VC_USERPASS, user.VC_DEPNAME, user.VC_ISADMIN, user.VC_CID, user.D_CDATE, user.VC_MID, user.D_MDATE, user.VC_ISDEL));
        }
    }
}
