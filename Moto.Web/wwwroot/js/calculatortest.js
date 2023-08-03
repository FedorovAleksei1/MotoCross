// Dark Mode Toggle
document.querySelector('.dark-mode-switch').onclick = () => {
    document.querySelector('body').classList.toggle('dark');
    document.querySelector('body').classList.toggle('light');
};

// Check Year
const isLeapYear = (year) => {
    return (year % 4 === 0 && year % 100 !== 0) || (year % 400 === 0);
};

const getDaysInMonth = (month, year) => {
    const monthIndex = month - 1; // Month index starts from 0
    const daysOfMonth = [
        31, // January
        28 + isLeapYear(year), // February
        31, // March
        30, // April
        31, // May
        30, // June
        31, // July
        31, // August
        30, // September
        31, // October
        30, // November
        31 // December
    ];
    return daysOfMonth[monthIndex];
};

const calendar = document.querySelector('.calendar');
const monthNames = [
    'Январь', 'Февраль', 'Март', 'Апрель', 'Май', 'Июнь',
    'Июль', 'Август', 'Сентябрь', 'Октябрь', 'Ноябрь', 'Декабрь'
];
const monthPicker = document.querySelector('#month-picker');

monthPicker.onclick = () => {
    monthList.classList.toggle('show');
};

// Generate Calendar
const generateCalendar = (month, year) => {
    const calendarDay = document.querySelector('.calendar-day');
    calendarDay.innerHTML = '';

    const calendarHeaderYear = document.querySelector('#year');
    const daysInMonth = getDaysInMonth(month, year);
    const currentDate = new Date();

    monthPicker.innerHTML = monthNames[month - 1];
    monthPicker.setAttribute('data-month', month);
    calendarHeaderYear.innerHTML = year;

    const firstDay = new Date(year, month - 1, 7);

    for (let i = 0; i < firstDay.getDay(); i++) {
        const emptyDay = document.createElement('div');
        calendarDay.appendChild(emptyDay);
    }

    for (let i = 1; i <= daysInMonth; i++) {
        const day = document.createElement('div');
        day.innerHTML = i;
        day.innerHTML += `<span></span>
                          <span></span>
                          <span></span>
                          <span></span>`;
        if (i === currentDate.getDate() && year === currentDate.getFullYear() && month === currentDate.getMonth() + 1) {
            day.classList.add('currDate');
        }
        calendarDay.appendChild(day);
    }
};

const monthList = calendar.querySelector('.month-list');
monthNames.forEach((month, index) => {
    const monthOption = document.createElement('div');
    monthOption.setAttribute('data-month', index + 1);
    monthOption.innerHTML = month;
    monthOption.onclick = () => {
        monthList.classList.remove('show');
        currMonth.value = index + 1;
        generateCalendar(currMonth.value, currYear.value);
    };
    monthList.appendChild(monthOption);
});

const prevYearBtn = document.querySelector('#prev-year');
prevYearBtn.onclick = () => {
    currYear.value--;
    generateCalendar(currMonth.value, currYear.value);
};

const nextYearBtn = document.querySelector('#next-year');
nextYearBtn.onclick = () => {
    currYear.value++;
    generateCalendar(currMonth.value, currYear.value);
};

const currentDate = new Date();
const currMonth = { value: currentDate.getMonth() + 1 };
const currYear = { value: currentDate.getFullYear() };

generateCalendar(currMonth.value, currYear.value);