const addTaskBtn = document.getElementById("add-task-btn");
const addTaskForm = document.getElementById("add-task-form");

addTaskBtn.addEventListener("click", function () {
    addTaskForm.classList.add("tasks-main__add-task__form--active");
})