const editBtns = document.querySelectorAll(".fa-solid.fa-pen");
const contents = document.querySelectorAll(".tasks-main__list__single-task__content");
const backdrop = document.getElementById("backdrop");
const backdropInputHidden = document.getElementById("AssignmentID");
const backdropInputContent = document.getElementById("Content");

//editBtns.forEach(function (btn) {
//    btn.addEventListener("click", function () {
//        btn.classList.add("fa-pen--hidden");
//    })
//})

for(let i = 0; i < editBtns.length; i++) {
    editBtns[i].addEventListener("click", function () {
        backdropInputHidden.value = editBtns[i].dataset.taskid;
        backdropInputContent.value = contents[i].textContent.trim();
        backdrop.classList.add("backdrop--active");
        backdropInputContent.focus();
        backdropInputContent.setSelectionRange(backdropInputContent.value.length, backdropInputContent.value.length);
    });
}

backdrop.addEventListener("click", function (event) {
    if (event.target == event.currentTarget) {
        backdrop.classList.remove("backdrop--active");
    }
});