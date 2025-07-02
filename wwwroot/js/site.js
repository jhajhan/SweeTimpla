// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//==================================================================kits functionality===============================================================
const kitData = {
    'palitaw': {
        name: "Palitaw Kit",
        price: 199,
        includes: "2 cups glutinous rice flour, ½ cup granulated sugar, 1 cup water, ½ cup sesame seeds roasted, 1 cup grated coconut",
        toolsNeeded: "Mixing Bowl, Measuring Cups, Cooking Pot, Tray, Serving Plate, Stove",
        prepTime: "10 minutes",
        cookTime: "15 minutes",
        totalTime: "25 minutes",
        servings: "4g",
        note: "Note: Cooking instructions will be provided after you place your order."
    },
    'puto': {
        name: "Puto Kit",
        price: 249,
        includes: "4 cups rice flour, 1 ½ cups sugar, 3 tablespoons baking powder, ½ teaspoon salt, 2 cups water, 1 can (13.5 ounces) coconut milk, non-stick cooking spray or melted butter",
        toolsNeeded: "Whisk, Puto Molds, Non-Stick Spray, Steamer",
        prepTime: "20 minutes",
        cookTime: "10 minutes",
        totalTime: "30 minutes",
        servings: "3 Dozens",
        note: "Note: Cooking instructions will be provided after you place your order."
    },
    'maja': {
        name: "Maja Blanca Kit",
        price: 279,
        includes: "4 cups coconut milk, 3/4 cup cornstarch, 14 ounces condensed milk, 3/4 cup fresh milk, 3/4 cup granulated sugar, 15 ounces whole sweet kernel corn, 5 tbsp toasted grated coconut",
        toolsNeeded: "Stove, Mixing Bowl, Refrigerator",
        prepTime: "8 minutes",
        cookTime: "35 minutes",
        totalTime: "43 minutes",
        servings: "8 People",
        note: "Note: Cooking instructions will be provided after you place your order."
    },
    'bukopandan': {
        name: "Buko Pandan Kit",
        price: 180,
        includes: "20 ounces young coconut strips, 250 ml Nestlé All Purpose Cream, 150 ml Nestlé Carnation Condensada, ½ cup cooked sago pearls optional, 2 cups water, 3 ounces powdered gelatin, ½ lb. pandan leaves, ¼ cup sugar, ½ teaspoon buko pandan flavoring",
        toolsNeeded: "Stove, Gelation Mold, Refrigerator, Strainer",
        prepTime: "30 minutes",
        cookTime: "15 minutes",
        totalTime: "8 hours (setting time for gelatin)",
        servings: "4 People",
        note: "Note: Cooking instructions will be provided after you place your order."
    },
    'turon': {
        name: "Turon Kit",
        price: 299,
        includes: "6 pieces bananas saba or plantains, cut in half (lengthwise), 1 cup jackfruit (ripe and sliced), 1 1/2 cup sugar, 12 pieces lumpia wrapper, 2 cups cooking oil",
        toolsNeeded: "Deep frying pan, Tongs, Knife",
        prepTime: "10 minutes",
        cookTime: "12 minutes",
        totalTime: "22 minutes",
        servings: "6 People",
        note: "Note: Cooking instructions will be provided after you place your order."
    },
    'ubehalaya': {
        name: "Ube Halaya Kit",
        price: 320,
        includes: "1 lb. grated purple yam, 1 14 oz. can condensed milk, 2 cups coconut milk, 3 tablespoons butter, 1 teaspoon ube flavoring, 1/2 cup shredded cheddar cheese",
        toolsNeeded: "Stove, Grater, Silicone Spatula",
        prepTime: "5 minutes",
        cookTime: "45 minutes",
        totalTime: "50 minutes",
        servings: "4g",
        note: "Note: Cooking instructions will be provided after you place your order."
    },
    'biko': {
        name: "Biko Kit",
        price: 210,
        includes: "2 cups glutinous rice aka sticky rice or malagkit, 1 1/2 cups water, 2 cups brown sugar, 4 cups coconut milk, 1/2 tsp salt",
        toolsNeeded: "Rice Cooker, Stove, Cooking Pot, Spatula",
        prepTime: "10 minutes",
        cookTime: "40 minutes",
        totalTime: "50 minutes",
        servings: "8 People",
        note: "Note: Cooking instructions will be provided after you place your order."
    },
    'lecheflan': {
        name: "Leche Flan Kit",
        price: 230,
        includes: "10 pieces eggs, 1 can condensed milk (14 oz), 1 cup fresh milk or evaporated milk, 1 cup granulated sugar, 1 teaspoon vanilla extract",
        toolsNeeded: "Llanera, Stove, Steamer, Refrigerator",
        prepTime: "10 minutes",
        cookTime: "45 minutes",
        totalTime: "55 minutes",
        servings: "6 people",
        note: "Note: Cooking instructions will be provided after you place your order."
    },
    'kutsinta': {
        name: "Kutsinta Kit",
        price: 175,
        includes: "1 1/2 cup rice flour, 1/2 cup all-purpose flour, 1 cup brown sugar, 3 cups water, 1 1/2 tsp lye water, 2 tsp anatto seeds",
        toolsNeeded: "Steamer, Stove, Grater, Kutsinta Molds",
        prepTime: "20 minutes",
        cookTime: "1 hour",
        totalTime: "1 hour and 20 minutes",
        servings: "6g",
        note: "Note: Cooking instructions will be provided after you place your order."
    },
    'cassavacake': {
        name: "Cassava Cake Kit",
        price: 260,
        includes: "2 lbs. cassava grated, 2 cups coconut cream, 12 ounces evaporated milk, 3 eggs, 3 tablespoons butter melted, 1/2 cup quick-melt cheese shredded, 14 ounces condensed milk",
        toolsNeeded: "Oven, Mixer, Grater, Baking Pan, Brush",
        prepTime: "10 minutes",
        cookTime: "1 hour",
        totalTime: "1 hour and 10 minutes",
        servings: "8 People",
        note: "Note: Cooking instructions will be provided after you place your order."
    },
    'ginataangbilobilo': {
        name: "Ginataang Bilo-Bilo Kit",
        price: 175,
        includes: "Banana, jackfruit, wrapper, sugar, oil20 pieces glutinous rice balls (Bilo-bilo), 20 oz jackfruit (ripe and sliced), 2 cups water, 2 cups coconut cream, 3/4 cup granulated white sugar, 1 1/2 cups tapioca pearls cooked",
        toolsNeeded: "Stove, Strainer, Ladle",
        prepTime: "5 minutes",
        cookTime: "40 minutes",
        totalTime: "45 minutes",
        servings: "6 People",
        note: "Note: Cooking instructions will be provided after you place your order."
    },
    'yema': {
        name: "Yema Balls Kit",
        price: 260,
        includes: "3 tbsp unsalted butter, 1 can 14 ounces condensed milk, 3 egg yolks, 3 tbsp peanuts chopped",
        toolsNeeded: "Stove, Saucepan, Spatula, Mixing Bowl",
        prepTime: "10 minutes",
        cookTime: "30 minutes",
        totalTime: "40 minutes",
        servings: "5g",
        note: "Note: Cooking instructions will be provided after you place your order."
    },
    'nilupak': {
        name: "Nilupak Kit",
        price: 175,
        includes: "1 lb. grated cassava, 1 cup shredded coconut, 1 can 14 oz. condensed milk, 3 tablespoons salted butter softened, 1/4 teaspoon salt",
        toolsNeeded: "Pan, Spatula, Molds, Banana Leaves, Grater",
        prepTime: "10 minutes",
        cookTime: "25 minutes",
        totalTime: "35 minutes",
        servings: "4g",
        note: "Note: Cooking instructions will be provided after you place your order."
    },
    'minatamisnasaging': {
        name: "Minatamis Na Saging Kit",
        price: 260,
        includes: "4 pieces saba banana saging na saba, 3/4 cup brown sugar, 1 1/2 cups water, 1 teaspoon vanilla extract, 1/4 teaspoon salt",
        toolsNeeded: "Cutting Board, Stove, Knife, Cooking Pot",
        prepTime: "10 minutes",
        cookTime: "30 minutes",
        totalTime: "40 minutes",
        servings: "4g",
        note: "Note: Cooking instructions will be provided after you place your order."
    },
    'pastillas': {
        name: "Pastillas De Leche Kit",
        price: 175,
        includes: "2 cups powdered milk sifted, 1 can 14 ounces condensed milk, ½ cup granulated sugar sifted",
        toolsNeeded: "Mixing Bowl, Spatula, Tray",
        prepTime: "10 minutes",
        cookTime: "1 minute",
        totalTime: "11 minutes",
        servings: "4g",
        note: "Note: Cooking instructions will be provided after you place your order."
    }
};

let cart = [];

  
        function openKitDetails(kitId) {
            fetch(`/DessertKit/GetKitDetails?kitId=${kitId}`)
                .then(response => {
                    if (!response.ok) throw new Error("Kit not found");
                    return response.json();
                })
                .then(data => {
                    // Fill modal fields
                    document.getElementById("kit-name").innerText = data.name;
                    document.getElementById("kit-includes").innerHTML = `<strong>What's included:</strong> ${data.includes}`;
                    document.getElementById("kit-tools").innerHTML = `<strong>Tools needed:</strong> ${data.tools}`;

                    document.getElementById("kit-prep").innerHTML = `
                <strong>Prep Time:</strong> ${data.prepTime}<br>
                <strong>Cook Time:</strong> ${data.cookTime}<br>
                <strong>Total Time:</strong> ${data.totalTime}<br>
                <strong>Servings:</strong> ${data.servings}
            `;

                    document.getElementById("kit-price").innerText = `₱${data.price}`;


                    // Show the modal
                    document.getElementById("kit-details-modal").classList.remove("hidden");
                })
                .catch(error => {
                    alert("Error loading kit: " + error.message);
                });
}

        function closeKitDetails() {
            document.getElementById("kit-details-modal").classList.add("hidden");
}
    




// add to cart
document.querySelectorAll('.add-to-cart').forEach(button => {
    button.addEventListener('click', e => {
        const key = e.currentTarget.dataset.kit;
        const selected = kitData[key];

        let cart = JSON.parse(localStorage.getItem('cart')) || [];
        const existing = cart.find(i => i.name === selected.name);
        if (existing) existing.quantity++;
        else cart.push({ ...selected, quantity: 1 });

        localStorage.setItem('cart', JSON.stringify(cart));
        closeKitDetails();
        showAddedMessage(`"${selected.name}" has been added to your cart!`);
    });
});

// added to your cart message
function showAddedMessage(message) {
    const msg = document.createElement('div');
    msg.textContent = message;
    msg.style.position = 'fixed';
    msg.style.bottom = '30px';
    msg.style.right = '30px';
    msg.style.backgroundColor = '#5A250F';
    msg.style.color = '#FFFFFF';
    msg.style.padding = '15px 20px';
    msg.style.borderRadius = '10px';
    msg.style.fontWeight = 'bold';
    msg.style.boxShadow = '0 4px 8px rgba(0, 0, 0, 0.3)';
    msg.style.zIndex = '9999';
    msg.style.transition = 'opacity 0.5s ease';

    document.body.appendChild(msg);

    setTimeout(() => {
        msg.style.opacity = '0';
        setTimeout(() => document.body.removeChild(msg), 500);
    }, 2500);
}

//================================================================================== Cart Functionality =================================================================================
// render cart items
function renderCart() {
    const tbody = document.querySelector('.cart-table tbody');
    tbody.innerHTML = '';

    // ✅ Get latest cart data from localStorage
    const cart = JSON.parse(localStorage.getItem('cart')) || [];

    let subtotal = 0;

    cart.forEach((item, i) => {
        const total = item.price * item.quantity;
        subtotal += total;

        tbody.insertAdjacentHTML('beforeend', `
      <tr>
        <td>${item.name}</td>
        <td>₱${item.price}</td>
        <td>
          <div class="quantity-control">
            <button onclick="changeQuantity(${i}, -1)">-</button>
            <span class="quantity">${item.quantity}</span>
            <button onclick="changeQuantity(${i}, 1)">+</button>
          </div>
        </td>
        <td>₱${total}</td>
        <td>
          <button class="remove-btn" onclick="removeItem(${i})">Remove</button>
        </td>
      </tr>
    `);
    });

    document.querySelector('.cart-summary p:nth-child(1)').innerHTML = `<strong>Subtotal:</strong> ₱${subtotal}`;
    const shipping = subtotal ? 50 : 0;
    document.querySelector('.cart-summary p:nth-child(2)').innerHTML = `<strong>Shipping:</strong> ₱${shipping}`;
    document.querySelector('.cart-summary p:nth-child(3)').innerHTML = `<strong>Total:</strong> <span id="cartTotal">₱${subtotal + shipping}</span>`;
}

function changeQuantity(index, delta) {
    const cart = JSON.parse(localStorage.getItem('cart')) || [];
    if (!cart[index]) return;
    const newQty = cart[index].quantity + delta;
    if (newQty < 1) return;
    cart[index].quantity = newQty;
    localStorage.setItem('cart', JSON.stringify(cart));
    renderCart();
}

function removeItem(i) {
    const cart = JSON.parse(localStorage.getItem('cart')) || [];
    cart.splice(i, 1);
    localStorage.setItem('cart', JSON.stringify(cart));
    renderCart();
}

document.addEventListener('DOMContentLoaded', () => {
    renderCart();
});


/*======================================================================== Delivery Information Functionality =================================================================================*/

// confirm modal
function openModal() {
    document.getElementById('checkoutModal').style.display = 'block';

    // Read the total price from the correct span
    const totalElement = document.getElementById('cartTotal');
    const totalAmount = totalElement ? totalElement.textContent : '₱0';

    // Set it inside the modal
    document.getElementById('modalTotalPrice').innerHTML = `<strong>Total Price: </strong>${totalAmount}`;
}

function closeModal() {
    document.getElementById('checkoutModal').style.display = 'none';
    // Reset QR code visibility and dropdown when closing
    document.getElementById('gcashQR').style.display = 'none';
    document.getElementById('paymentMethod').value = "";
}

function handlePaymentChange() {
    const paymentMethod = document.getElementById('paymentMethod').value;
    const gcashQR = document.getElementById('gcashQR');

    if (paymentMethod === "gcash") {
        gcashQR.style.display = "block";
    } else {
        gcashQR.style.display = "none";
    }
}

// close modal by clicking outside
window.onclick = function (event) {
    const modal = document.getElementById("checkoutModal");
    if (event.target == modal) {
        closeModal();
    }
};

function confirmOrder() {
    const name = document.querySelector('#checkoutModal input[placeholder="Full Name"]').value.trim();
    const address = document.querySelector('#checkoutModal input[placeholder="Address"]').value.trim();
    const contact = document.querySelector('#checkoutModal input[placeholder="Contact Number (e.g., 09164524332)"]').value.trim();
    const paymentMethod = document.getElementById('paymentMethod').value;

    if (!name || !address || !contact || !paymentMethod) {
        Swal.fire({
            title: 'Incomplete Information',
            text: 'Please fill in all fields and select a payment method.',
            icon: 'warning',
            background: '#FFE3A8',
            color: '#5A250F',
            confirmButtonColor: '#A3D86B',
            confirmButtonText: 'Okay',
        });
        return;
    }

    const contactRegex = /^09\d{9}$/;
    if (!contactRegex.test(contact)) {
        Swal.fire({
            title: 'Invalid Contact Number',
            text: 'Please enter a valid contact number (e.g., 09164524332).',
            icon: 'error',
            background: '#FFE3A8',
            color: '#5A250F',
            confirmButtonColor: '#A3D86B',
            confirmButtonText: 'Got it',
        });
        return;
    }

    if (paymentMethod === "gcash") {
        Swal.fire({
            title: 'GCash Confirmation',
            text: 'Have you already scanned and paid using GCash?',
            icon: 'question',
            showCancelButton: true,
            confirmButtonColor: '#A3D86B',
            cancelButtonColor: '#5A250F',
            background: '#FFE3A8',
            color: '#000000',
            confirmButtonText: 'Yes, I have paid',
            cancelButtonText: 'Not yet',
        }).then((result) => {
            if (result.isConfirmed) {
                showFinalConfirmation();
            } else {
                reopenCheckoutModal();
            }
        });
    } else {
        showFinalConfirmation();
    }

    function showFinalConfirmation() {
        Swal.fire({
            title: 'Confirm Your Order',
            text: 'Do you confirm this order? Please double-check all your information before continuing.',
            icon: 'info',
            showCancelButton: true,
            confirmButtonText: 'Yes, Place Order',
            cancelButtonText: 'Cancel',
            confirmButtonColor: '#A3D86B',
            cancelButtonColor: '#5A250F',
            background: '#FFE3A8',
            color: '#000000',
        }).then((result) => {
            if (result.isConfirmed) {
                placeOrder();
            } else {
                reopenCheckoutModal();
            }
        });
    }

    function placeOrder() {

        // Close checkout modal
        closeModal();

        // Clear cart and re-render
        cart.length = 0;
        renderCart();

        // Open instructions modal
        document.getElementById('instructionsModal').style.display = 'block';
    }

    function reopenCheckoutModal() {
        const checkoutModal = document.getElementById('checkoutModal');
        if (checkoutModal) {
            checkoutModal.style.display = 'block';
        }
    }
}

function downloadInstructions() {
    const instructions = `
Thank you for placing your order!

Here's the Cooking instructions:

- Combine the sticky rice and water in a rice cooker and cook until the rice is ready (we intentionally combined lesser amount of water than the usual so that the rice will not be fully cooked)
- While the rice is cooking, combine the coconut milk with brown sugar and salt in a separate pot and cook in low heat until the texture becomes thick. Stir constantly.
- Once the rice is cooked and the coconut milk-sugar mixture is thick enough, add the cooked rice in the coconut milk and sugar mixture then mix well. Continue cooking until all the liquid evaporates (but do not overcook).
- Scoop the cooked biko and place it in a serving plate then flatten the surface.
- Share and Enjoy!

— Your Friendly Store, 
- SweeTimpla
`;

    const blob = new Blob([instructions], { type: 'text/plain' });
    const link = document.createElement('a');
    link.href = URL.createObjectURL(blob);
    link.download = 'Order_Instructions.txt';
    link.click();
}

function closeInstructionsModal() {
    document.getElementById('instructionsModal').style.display = 'none';
}


//======================================================================== Track Order Functionality ========================================================================
function goToTrackOrder() {

    window.location.href = 'trackorder.html';
    document.getElementById('instructionsModal').style.display = 'none';


    document.getElementById('trackOrder').scrollIntoView({ behavior: 'smooth' });
}

window.onclick = function (event) {
    const modal = document.getElementById('instructionsModal');
    if (event.target == modal) {
        modal.style.display = 'none';
    }
}

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

//document.getElementById('showLoginModalBtn').addEventListener('click', function () {
//    const modal = document.getElementById('loginSignupModal');
//    modal.style.display = "block";
//    modal.classList.add("show");
//    document.body.classList.add('modal-open');
//});

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


