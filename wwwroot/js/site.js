// Switch between Sign In and Sign Up
function switchToSignUp(e) {
    e.preventDefault();
    document.getElementById('loginForm').style.display = 'none';
    document.getElementById('signUpForm').style.display = 'block';
    document.querySelector('#loginSignupModal h2').innerText = 'Sign Up';
}
function switchToLogin(e) {
    e.preventDefault();
    document.getElementById('signUpForm').style.display = 'none';
    document.getElementById('loginForm').style.display = 'block';
    document.querySelector('#loginSignupModal h2').innerText = 'Sign In';
}

// Password show/hide (eye icon)
function togglePassword(inputId, el) {
    const input = document.getElementById(inputId);
    if (!input) return;
    if (input.type === "password") {
        input.type = "text";
        el.querySelector('svg').innerHTML = `<circle cx="12" cy="12" r="3"></circle>
        <path d="M2 12s4-7 10-7 10 7 10 7-4 7-10 7S2 12 2 12z"></path>`;
    } else {
        input.type = "password";
        el.querySelector('svg').innerHTML = `<circle cx="12" cy="12" r="3"></circle>
        <path d="M2 12s4-7 10-7 10 7 10 7-4 7-10 7S2 12 2 12z"></path>
        <line x1="4" y1="4" x2="20" y2="20" stroke-width="2"></line>`;
    }
}

// Forgot password modal
document.getElementById('forgotPasswordLink').addEventListener('click', function (e) {
    e.preventDefault();
    document.getElementById('loginSignupModal').style.display = 'none';
    let forgotModal = new bootstrap.Modal(document.getElementById('forgotModal'));
    forgotModal.show();
    document.body.classList.add('modal-open');
});

document.getElementById('showLoginModalBtn').addEventListener('click', function () {
    const modal = document.getElementById('loginSignupModal');
    modal.style.display = "block";
    modal.classList.add("show");
    document.body.classList.add('modal-open');
});

function hideLoginModal() {
    const modal = document.getElementById('loginSignupModal');
    modal.style.display = "none";
    modal.classList.remove("show");
    document.body.classList.remove('modal-open');
}

document.addEventListener('DOMContentLoaded', function () {
    const closeBtns = document.querySelectorAll('#loginSignupModal .btn-close');
    closeBtns.forEach(btn => {
        btn.onclick = hideLoginModal;
    });
    document.getElementById('loginSignupModal').addEventListener('click', function (e) {
        if (e.target === this) hideLoginModal();
    });
});

function switchToLoginFromForgot(e) {
    e.preventDefault();
    // Hide the forgot password modal
    var forgotModal = bootstrap.Modal.getInstance(document.getElementById('forgotModal'));
    forgotModal.hide();
    // Show the login/signup modal
    document.getElementById('loginSignupModal').style.display = "block";
    document.getElementById('loginForm').style.display = "block";
    document.getElementById('signUpForm').style.display = "none";
    document.querySelector('#loginSignupModal h2').innerText = 'Sign In';
}
