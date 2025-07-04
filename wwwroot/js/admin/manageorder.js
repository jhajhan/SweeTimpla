let currentEditingRow = null;

document.addEventListener("DOMContentLoaded", function () {
    const editButtons = document.querySelectorAll(".edit-btn");
    const modal = document.getElementById("editModal");
    const closeBtn = modal.querySelector(".close");
    const orderIdInput = document.getElementById("editOrderId");
    const statusSelect = document.getElementById("orderStatus");
    const paymentStatusSelect = document.getElementById("paymentStatus");


    editButtons.forEach(button => {
        button.addEventListener("click", () => {
            const orderId = button.getAttribute("data-order-id");
            const status = button.getAttribute("data-order-status");
            const paymentStatus = button.getAttribute("data-payment-status");

            // Set values in modal
            orderIdInput.value = orderId;
            statusSelect.value = status;
            paymentStatusSelect.value = paymentStatus;

            // Show modal
            modal.style.display = "block";
        });
    });

    // Close modal
    closeBtn.addEventListener("click", () => {
        modal.style.display = "none";
    });

    window.addEventListener("click", (e) => {
        if (e.target === modal) {
            modal.style.display = "none";
        }
    });
});




function saveEdit() {
    if (!currentEditingRow) return;

    const cells = currentEditingRow.querySelectorAll("td");

    // Update the row with new values
    cells[1].innerText = document.getElementById("editName").value;
    cells[2].innerText = document.getElementById("editIngredients").value;
    cells[3].innerText = document.getElementById("editTools").value;
    cells[4].innerText = document.getElementById("editPrepTime").value;
    cells[5].innerText = document.getElementById("editServingSize").value;
    cells[6].innerText = `₱${parseFloat(document.getElementById("editPrice").value).toFixed(2)}`;
    cells[7].innerText = document.getElementById("editQuantity").value;
    cells[8].innerText = document.getElementById("editIsFeatured").value === "true" ? "Yes" : "No";
    cells[9].innerText = document.getElementById("editCookTime").value;
    cells[10].innerText = document.getElementById("editTotalTime").value;

    closeEditModal();

    if (typeof Swal !== 'undefined') {
        Swal.fire({
            icon: 'success',
            title: 'Success!',
            text: 'Dessert kit updated successfully.',
            timer: 1500,
            showConfirmButton: false
        });
    }
}

function confirmDelete(event, form) {
    event.preventDefault(); // Stop form from submitting right away

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
                // Submit the form manually
                form.submit();
            }
        });
    } else {
        // Fallback for when SweetAlert is not available
        if (confirm('Are you sure you want to delete this dessert kit?')) {
            form.submit();
        }
    }

    return false; // Prevent default submit for now
}

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
            document.getElementById("editForm").submit();
        }
    });

    return false;
}


function updateRowNumbers() {
    const tbody = document.getElementById('kit-body');
    const rows = tbody.querySelectorAll('tr');
    rows.forEach((row, index) => {
        row.querySelector('td').innerText = index + 1;
    });
}

document.addEventListener('click', function (event) {
    const modal = document.getElementById('editModal');
    if (event.target === modal) {
        closeEditModal();
    }
});

document.addEventListener('keydown', function (event) {
    if (event.key === 'Escape') {
        closeEditModal();
    }
});

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