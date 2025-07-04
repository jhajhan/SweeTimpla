let currentEditingRow = null;

document.addEventListener("DOMContentLoaded", function () {
    const editButtons = document.querySelectorAll(".edit-btn");
    const modal = document.getElementById("editModal");
    const closeBtn = modal.querySelector(".close-btn");

    // Modal input fields
    const editId = document.getElementById("editId");
    const editName = document.getElementById("editName");
    const editIngredients = document.getElementById("editIngredients");
    const editTools = document.getElementById("editTools");
    const editPrepTime = document.getElementById("editPrepTime");
    const editServingSize = document.getElementById("editServingSize");
    const editPrice = document.getElementById("editPrice");
    const editQuantity = document.getElementById("editQuantity");
    const editIsFeatured = document.getElementById("editIsFeatured");
    const editCookTime = document.getElementById("editCookTime");
    const editTotalTime = document.getElementById("editTotalTime");
    const editInstructions = document.getElementById("editInstructions");
    const editImageUrl = document.getElementById("editImageUrl");
    const editDescription = document.getElementById("editDescription");
    // Attach click listeners to all edit buttons
    editButtons.forEach(button => {
        button.addEventListener("click", () => {
            currentEditingRow = button.closest("tr");

            // Populate modal fields with data attributes
            editId.value = button.getAttribute("data-id");
            editName.value = button.getAttribute("data-name");
            editIngredients.value = button.getAttribute("data-ingredients");
            editTools.value = button.getAttribute("data-tools");
            editPrepTime.value = button.getAttribute("data-preptime");
            editServingSize.value = button.getAttribute("data-serving");
            editPrice.value = button.getAttribute("data-price");
            editQuantity.value = button.getAttribute("data-quantity");
            editIsFeatured.value = button.getAttribute("data-isfeatured") === "True" ? "true" : "false";
            editCookTime.value = button.getAttribute("data-cooktime");
            editTotalTime.value = button.getAttribute("data-totaltime");
            editInstructions.value = button.getAttribute("data-instructions");
            editImageUrl.value = button.getAttribute("data-imageurl");
            editDescription.value = button.getAttribute("data-description")

            modal.classList.remove("hidden");
        });
    });

    // Close modal on close button click
    closeBtn.addEventListener("click", () => {
        closeEditModal();
    });
});

// Function to hide the modal
function closeEditModal() {
    const modal = document.getElementById("editModal");
    modal.classList.add("hidden");
}

// Confirm delete with SweetAlert fallback
function confirmDelete(event, form) {
    event.preventDefault();

    if (typeof Swal !== 'undefined') {
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#e74c3c',
            cancelButtonColor: '#A3D86B',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                form.submit();
            }
        });
    } else {
        if (confirm('Are you sure you want to delete this dessert kit?')) {
            form.submit();
        }
    }

    return false;
}

// Confirm save with SweetAlert
function confirmSave(event) {
    event.preventDefault();

    Swal.fire({
        title: 'Save changes?',
        text: "Are you sure you want to apply these changes?",
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'Yes, save',
        cancelButtonText: 'Cancel',
        confirmButtonColor: '#4CAF50',
        cancelButtonColor: '#ccc'
    }).then((result) => {
        if (result.isConfirmed) {
            document.querySelector("#editModal form").submit();
        }
    });

    return false;
}

function confirmLogout(event, form) {
    event.preventDefault();

    Swal.fire({
        title: 'Log out?',
        text: "Are you sure you want to log out?",
        icon: 'question',
        showCancelButton: true,
        confirmButtonColor: '#A3D86B',
        cancelButtonColor: '#ccc',
        confirmButtonText: 'Yes, log out'
    }).then((result) => {
        if (result.isConfirmed) {
            form.submit();
        }
    });

    return false;
}