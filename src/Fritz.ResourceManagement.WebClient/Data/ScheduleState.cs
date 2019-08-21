using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fritz.ResourceManagement.Domain;

namespace Fritz.ResourceManagement.WebClient.Data
{

	public class ScheduleState
	{

		public Schedule Schedule { get; set; }

		public int ScheduleId { get; set; }

		public DateTime SelectedDate { get; private set; } = DateTime.Today;

		public DateTime DisplayBeginDate { get; set; }

		public DateTime DisplayEndDate { get; set; }

		public void SelectDate(DateTime newDate)
		{
			SelectedDate = newDate;
			OnSelectedDateChanged?.Invoke(null, new SelectedDateChangedArgs() { SelectedDate = newDate });
		}

		public List<TimeSlot> TimeSlots { get; } = new List<TimeSlot>();

		public void SetTimeSlots(IEnumerable<TimeSlot> newTimeSlots) {

			TimeSlots.Clear();
			TimeSlots.AddRange(newTimeSlots);

			OnTimeSlotsChanged?.Invoke(null, new TimeSlotsChangedArgs());
					 
		}

		public void ScheduleUpdated()
		{
			ExpandSchedule();
			OnSelectedDateChanged?.Invoke(null, new SelectedDateChangedArgs() { SelectedDate = SelectedDate });
		}

		public void ExpandSchedule()
		{

			// ExpandSchedule(SelectedDate.AddMonths(-2), SelectedDate.AddMonths(3));

		}

		public void ExpandSchedule(DateTime minStartDate, DateTime maxEndDate)
		{

			// TODO: Move to server controller
			//var mgr = new ScheduleManager();
			//TimeSlots.Clear();
			//TimeSlots.AddRange(mgr.ExpandSchedule(Schedule, minStartDate, maxEndDate));

		}

		public event EventHandler<SelectedDateChangedArgs> OnSelectedDateChanged;

		public event EventHandler<TimeSlotsChangedArgs> OnTimeSlotsChanged;

		public class SelectedDateChangedArgs : EventArgs
		{

			public DateTime SelectedDate { get; set; }

		}

		public class TimeSlotsChangedArgs
		{

		}

	}


}
