import { Link as Link } from "react-router-dom";

const Nav = () => {
  return (
    <nav className="navbar navbar-expanded-lg navbar-light bg-light">
      <ul className="navbar-nav me- mb-2 mb-lg-0">

        <li className="nav-item">
          <Link className="nav-link" to='/'>Home</Link>
        </li>

        <li className="nav-item">
          <Link className="nav-link" to='/GroupedTeamMembers'>Teams</Link>
        </li>

      </ul>
    </nav>
  )
}

export default Nav;