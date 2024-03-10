const taskList = document.getElementById("task-list");
const backdrop = document.getElementById("backdrop");
const cancelBtn = backdrop.querySelector("#edit-task-cancel-btn");
const assignmentID = backdrop.querySelector("#AssignmentID");
const content = backdrop.querySelector("#Content");

taskList.addEventListener("click", async function (event) {
    if (event.target.classList.contains("fa-pen")) {
        //event.preventDefault();
        //const href = event.target.closest('a').href;

        //let response = await fetch(href);

        //responseHTML = await response.text();
        //document.body.insertAdjacentHTML("beforeend", responseHTML);

        //const backdrop = document.getElementById("backdrop");
        //const cancelBtn = backdrop.querySelector("#edit-task-cancel-btn");

        assignmentID.value = event.target.dataset.taskid;
        content.value = event.target.dataset.taskcontent;

        backdrop.classList.add("backdrop--active");

        //backdrop.addEventListener("click", function (event) {
        //    if (event.target == event.currentTarget) {
        //        document.body.removeChild(backdrop);
        //    }
        //});

        //cancelBtn.addEventListener("click", function () {
        //    document.body.removeChild(backdrop);
        //})
    }
});

backdrop.addEventListener("click", function (event) {
    if (event.target == event.currentTarget) {
        backdrop.classList.remove("backdrop--active");
    }
});

cancelBtn.addEventListener("click", function () {
    backdrop.classList.remove("backdrop--active");
})