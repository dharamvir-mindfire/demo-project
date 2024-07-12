import React, { PropsWithChildren } from 'react';
import { render, screen, fireEvent, act, waitFor } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect'; // for matchers like .toBeInTheDocument
import { useRegisterMutation } from '../../services/authServices';
import Registration from '.';
import { BrowserRouter as Router } from 'react-router-dom';

const mockData = {
  fullName: "Dharamvir",
  email: 'dharamvir@example.com',
  phoneNumber: '9999955555',
  password: 'Nokia@123',
}
// Mock the register mutation hook
jest.mock('../../services/authServices', () => ({
  useRegisterMutation: jest.fn(),
}));

const mockRegisterUser = jest.fn();

beforeEach(() => {
  (useRegisterMutation as jest.Mock).mockReturnValue([mockRegisterUser]);
});

describe('Registration form', () => {
  test('renders Registration component', () => {
    render(
      <Router>
        <Registration />
      </Router>
    );

    expect(screen.getByText(/New Registration/i)).toBeInTheDocument();
    expect(screen.getByText(/Full name/i)).toBeInTheDocument();
    expect(screen.getByText(/Email/i)).toBeInTheDocument();
    expect(screen.getByText(/Phone Number/i)).toBeInTheDocument();
    expect(screen.getByText(/Password/i)).toBeInTheDocument();
    expect(screen.getByText(/Sign up/i)).toBeInTheDocument();
    expect(screen.getByText(/Existing User/i)).toBeInTheDocument();
  });
  it('submits the form with correct data', async () => {
    mockRegisterUser.mockResolvedValue({ data: 'Registration successful!' });
    const { getByTestId } = render(
      <Router>
        <Registration />
      </Router>
    );

    fireEvent.change(getByTestId("fullName"), {
      target: { value: mockData?.fullName },
    });
    fireEvent.change(getByTestId("email"), {
      target: { value: mockData?.email },
    });
    fireEvent.change(getByTestId("phoneNumber"), {
      target: { value: mockData?.phoneNumber },
    });
    fireEvent.change(getByTestId("password"), {
      target: { value: mockData?.password },
    });
    await act(async () => {
      fireEvent.click(getByTestId('sign-up'));
    })

    await waitFor(() => {
      expect(mockRegisterUser).toHaveBeenCalledWith(mockData);
      expect(screen.getByText(/Registered Successfully/i)).toBeInTheDocument();
    });
  });

});
