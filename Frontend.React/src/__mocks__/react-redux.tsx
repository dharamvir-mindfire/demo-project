// __mocks__/react-redux.js
const React = require('react');

const mockConnect = (mapStateToProps, mapDispatchToProps) => (Component) => {
  const MockedComponent = (props) => <Component {...props} />;
  const mapStateToPropsResult = mapStateToProps ? mapStateToProps({}) : {};
  const mapDispatchToPropsResult = mapDispatchToProps ? mapDispatchToProps(jest.fn()) : {};
  return (props) => (
    <MockedComponent {...mapStateToPropsResult} {...mapDispatchToPropsResult} {...props} />
  );
};

module.exports = {
  connect: jest.fn().mockImplementation(mockConnect),
};
