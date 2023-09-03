using System;
using System.Collections;
using UnityEngine;

namespace Player.Controllers
{
    public class PlayerShooterController : MonoBehaviour
    {
        public ParticleSystem[] muzzleFlash;
        public Transform raycastOrigin;
  
        public TrailRenderer TrailEffect;

        private Ray _ray;
        private RaycastHit _raycastHit;

        
        public bool isFiring;

        public void StartFiring(Vector3 raycastDestination)
        {
            isFiring = true;

            foreach (var particle in muzzleFlash)
            {
                particle.Emit(1);
            }

            _ray.origin = raycastOrigin.position;
            _ray.direction = raycastOrigin.forward;

            var tracer = Instantiate(TrailEffect, _ray.origin, Quaternion.identity);
            tracer.AddPosition(_ray.origin);
            
            Debug.DrawLine(_ray.origin,_ray.direction,Color.red);
            
            if (Physics.Raycast(_ray, out _raycastHit))
            {
                tracer.transform.position = _raycastHit.point;

                if (_raycastHit.transform.TryGetComponent(out IDamageable damageable))
                {
                    damageable.TakeDamage(100f);
                }
        
            }
        }

        public void StopFiring()
        {
            isFiring = false;
        }
    }

    public interface IDamageable
    {
        void TakeDamage(float amount);
    }
}