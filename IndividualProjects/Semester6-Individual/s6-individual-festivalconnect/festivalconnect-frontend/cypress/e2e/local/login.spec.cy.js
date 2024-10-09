describe('Login Input Fields', () => {
  beforeEach(() => {
    cy.visit('localhost:5173/login'); // Assuming '/login' is the URL for the Login page
  });

  it('displays error message if email field is empty', () => {
    cy.get('#password').type('password123'); // Fill in only the password field
    cy.get('button').click()
    cy.get('#error').should('contain', 'Please fill out all fields.'); // Check for error message
    //cy.get('[id="error"]', {timeout: 5000}).should('contain', 'Please fill out all fields.')
  });

  it('displays error message for invalid email format', () => {
    cy.get('#email').type('invalidemail'); // Fill in an invalid email format
    cy.get('#password').type('password123'); // Fill in the password field
    cy.get('button').click()
    cy.get('#error').should('contain', 'Please enter a valid email.'); // Check for error message
  });

/*it('successfully logs in with valid credentials', () => {
    // Intercept the login request and mock a successful response
    cy.intercept('POST', 'http://localhost:5000/Identity/login', { statusCode: 200, body: {token: 'dummyToken' } }).as('loginRequest');

    // Visit the login page
    cy.visit('/login'); // Ensure this path matches your application's login page URL

    // Fill in the login form
    cy.get('#email').type('test@example.com'); // Fill in a valid email
    cy.get('#password').type('password123'); // Fill in a valid password
    cy.get('button').click();

    // Wait for the login request to complete
    cy.wait('@loginRequest').then((interception) => {
        // Log the intercepted request and response for debugging
        console.log('Intercepted request:', interception);

        // Check if the token cookie is set
        cy.getCookie('token').should('exist').and('have.property', 'value', 'dummyToken');
        
        // Check if user is redirected after successful login (assuming '/')
        cy.url().should('include', '/');
    });
});*/

});