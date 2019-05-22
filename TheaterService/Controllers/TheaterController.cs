using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace TheaterService.Controllers
{
    [RoutePrefix("api/actions")]
    public class TheaterController : Controller
    {

        //Data List
        private List<Models.Action> actionModel = new List<Models.Action>();

        #region GET

        [HttpGet, Route("/all")]
        public JsonResult GetActions()
        {
            try
            {
                using (DB.DB model = new DB.DB())
                {
                    var list = from Action in model.Action
                               select new Models.Action()
                               {
                                   action_id = Action.id,
                                   hall_name = Action.hall_name,
                                   spectacle_name = Action.spectacle_name,
                                   seats_count = Action.seats_count,
                                   available_seats = Action.available_seats,
                                   booked_seats = Action.booked_seats
                               };
                    actionModel = list.ToList();
                    return Json(actionModel);
                }
            }catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }

        #endregion

        #region POST

        [HttpPost, Route("/add")]
        [ResponseType(typeof(void))]
        public string PostAction(DB.Action action)
        {
            string result = string.Empty;
            try
            {
                using (DB.DB model = new DB.DB())
                {
                    model.Action.Add(action);
                    model.SaveChanges();
                    result = "Data Inserted";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        #endregion

        #region PUT

        [HttpPut, Route("/update")]
        [ResponseType(typeof(void))]
        public string PutAction(DB.Action action)
        {
            string result = string.Empty;
            try
            {
                using(DB.DB model = new DB.DB())
                {
                    var actionVar = model.Action.Where(c => action.id.Equals(c.id)).FirstOrDefault();
                    if(actionVar != null)
                    {
                        actionVar = action;
                        model.SaveChanges();
                        result = "Data Updated";
                    }
                    else
                    {
                        result = "Data Not Found";
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        #endregion

        #region DELETE
        [HttpDelete, Route("{id}")]
        public string DeleteAction(int id)
        {
            string result = string.Empty;
            try
            {
                using(DB.DB model = new DB.DB())
                {
                    var actionVar = model.Action.Where(c => c.id.Equals(id)).FirstOrDefault();
                    if (actionVar != null)
                    {
                        model.Action.Remove(actionVar);
                        model.SaveChanges();
                        result = "Data Deleted";
                    }
                    else
                    {
                        result = "Data Not Found";
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        #endregion
    }
}
