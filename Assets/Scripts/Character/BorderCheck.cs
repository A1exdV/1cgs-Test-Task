using UnityEngine;

namespace Character
{
    public class BorderCheck
    {
        private float _radius;
    
        private float _xBorder, _yBorder;
    
        public BorderCheck(float radius)
        {
            GroundBorders.SubscribeToSendGroundBorders(GetGroundBorders);
            _radius = radius;
        }

        private void GetGroundBorders(Borders borders)
        {
            _xBorder = borders.X;
            _yBorder = borders.Y;
        }

        /// <summary>
        /// Check possition to collide with borders
        /// </summary>
        /// <param name="nextPosition"></param>
        /// <returns></returns>
        public bool CheckForBordersCollision(Vector2 nextPosition)
        {
            if (nextPosition.x - _radius < -_xBorder || nextPosition.x + _radius > _xBorder ||
                nextPosition.y - _radius < -_yBorder || nextPosition.y + _radius > _yBorder)
            {
                return false;
            }

            return true;
        }

        public void OnDisable()
        {
            GroundBorders.UnsubscribeFromSendGroundBorders(GetGroundBorders);
        }
    }
}
