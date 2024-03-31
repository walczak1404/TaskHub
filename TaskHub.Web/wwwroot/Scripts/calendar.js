const daysTag = document.querySelector(".days"),
currentDate = document.querySelector(".current-date"),
    prevNextIcon = document.querySelectorAll(".icons span");

const selectedDateArr = daysTag.dataset.selectedDate.split(".");

// getting new date, selected year and month
let selectedDate = new Date(selectedDateArr[2], selectedDateArr[1] - 1, selectedDateArr[0]),
    currYear = selectedDate.getFullYear(),
    currMonth = selectedDate.getMonth(),
    selectedYear = selectedDate.getFullYear();
    selectedMonth = selectedDate.getMonth();

let date = new Date();


// storing full name of all months in array
const months = ["January", "February", "March", "April", "May", "June", "July",
              "August", "September", "October", "November", "December"];
const renderCalendar = () => {
    let firstDayofMonth = new Date(currYear, currMonth, 0).getDay(), // getting first day of month
    lastDateofMonth = new Date(currYear, currMonth + 1, 0).getDate(), // getting last date of month
    lastDayofMonth = new Date(currYear, currMonth, lastDateofMonth).getDay(), // getting last day of month
    lastDateofLastMonth = new Date(currYear, currMonth, 0).getDate(); // getting last date of previous month
    let liTag = "";
    for (let i = firstDayofMonth; i > 0; i--) { // creating li of previous month last days
        tempDate = new Date(currYear, currMonth, 1);
        tempDate.setMonth(tempDate.getMonth() - 1);

        tempDateString = `${tempDate.getFullYear()}-${tempDate.getMonth() + 1}-${lastDateofLastMonth - i + 1}`;

        liTag += `<li class="inactive"><a href='/${tempDateString}'>${lastDateofLastMonth - i + 1}</a></li>`;
    }
    for (let i = 1; i <= lastDateofMonth; i++) { // creating li of all days of current month
        // adding active class to li if the current day, month, and year matched
        let isToday = i === date.getDate() && currMonth === new Date().getMonth() 
            && currYear === new Date().getFullYear() ? "today" : "";

        let isSelectedDay = i === selectedDate.getDate() && selectedMonth === currMonth && selectedYear === currYear ? "selected-day" : "";
        liTag += `<li class="${isToday} ${isSelectedDay}"><a href='/${currYear}-${currMonth+1}-${i}'>${i}</a></li>`;
    }

    for (let i = lastDayofMonth; i < 7 && i > 0; i++) { // creating li of next month first days
        tempDate = new Date(currYear, currMonth, 1);
        tempDate.setMonth(tempDate.getMonth() + 1);

        tempDateString = `${tempDate.getFullYear()}-${tempDate.getMonth() + 1}-${i - lastDayofMonth + 1}`;

        liTag += `<li class="inactive"><a href='${tempDateString}'>${i - lastDayofMonth + 1}</a></li>`
    }
    currentDate.innerText = `${months[currMonth]} ${currYear}`; // passing current mon and yr as currentDate text
    daysTag.innerHTML = liTag;
}
renderCalendar();
prevNextIcon.forEach(icon => { // getting prev and next icons
    icon.addEventListener("click", () => { // adding click event on both icons
        // if clicked icon is previous icon then decrement current month by 1 else increment it by 1
        currMonth = icon.id === "prev" ? currMonth - 1 : currMonth + 1;
        if(currMonth < 0 || currMonth > 11) { // if current month is less than 0 or greater than 11
            // creating a new date of current year & month and pass it as date value
            date = new Date(currYear, currMonth, new Date().getDate());
            currYear = date.getFullYear(); // updating current year with new date year
            currMonth = date.getMonth(); // updating current month with new date month
        } else {
            date = new Date(); // pass the current date as date value
        }
        renderCalendar(); // calling renderCalendar function
    });
});